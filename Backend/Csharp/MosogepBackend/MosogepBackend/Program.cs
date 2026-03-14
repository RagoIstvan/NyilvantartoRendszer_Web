using Microsoft.EntityFrameworkCore;
using MosogepBackend.Controller_Api;
using MosogepBackend.Factorys;
using MosogepBackend.Models;
using MosogepBackend.Querys_Linq;
using MosogepBackend.Services;

namespace MosogepBackend
{
    public class Program
    {
        static async Task Main(string[] args)
        {


            try
            {

                Data.Datadb db = new Data.Datadb();
                await db.Database.EnsureDeletedAsync();
                await db.Database.EnsureCreatedAsync();


                // EN: Manual Dependency Injection (DI) setup
                Kalkulator kalkulator = new Kalkulator();
                HibaGenerator egyhiba = new HibaGenerator(db, kalkulator);


                HttpClient client = new HttpClient();
                ArfolyamSzamolApi szamol = new ArfolyamSzamolApi(client);
                HibaKuldesPyhton kuld = new HibaKuldesPyhton(client);
                KommunikacioJava kuldjava = new KommunikacioJava(client, db);

                // EN: Fetching live data before starting the main logic
                decimal arfolyam = await szamol.Arfolyamkeres(ArfolyamSzamolApi.Url);


                Ellenorzes ujellenorzes = new Ellenorzes();
                RandomGyartas gyartas = new RandomGyartas(arfolyam, kalkulator, ujellenorzes, db);
                CsvReader reader = new CsvReader(arfolyam, kalkulator, ujellenorzes, db);
                QuerysFails querys = new QuerysFails(db);


                var admin = new User("Teszt Elek", "user1@test.com", "1234567");



                db.User.Add(admin);
                await db.SaveChangesAsync();


                gyartas.MosogepGeneral(admin);
                reader.Reader(admin);


                var gepek = db.Gepek.ToList();


                foreach (var sor in gepek)
                {

                    Console.WriteLine(sor);
                }


                Console.WriteLine("-25");

                egyhiba.EgyHibaMentese();

                // var rosszGepek = db.Gepek
                //                 .Include(m => m.Hibak)
                //                 .Include(m => m.Gyarto)
                //                 .Where(x => x.Hibak.Any())
                //                 .ToList();

                // foreach (var gep in rosszGepek)
                // {
                //     var aktualisHiba = gep.Hibak.LastOrDefault();

                //     Console.WriteLine($"{gep.Azonosito} \n {aktualisHiba}");
                // }


                // Console.WriteLine("----------25");

                querys.HibakLekerdezese();

                var hibak = db.Hiba.ToList();

                var index = hibak.Select(x => x.MosogepId).FirstOrDefault();

                var gep = db.Gepek.FirstOrDefault(x => x.Id == index);

                var adatokPythonnak = db.Hiba
                    .Select(h => new
                    {
                       
                        GepNeve = db.Gepek.Where(g => g.Id == h.MosogepId).Select(g => g.Gyarto.Nev).FirstOrDefault(),
                        HibaAdat = h
                    })
                    .Select(z => new
                    {
                        gyarto= z.GepNeve,
                        hibakod = z.HibaAdat.Hibakod.ToString(),
                        hibaktsg = z.HibaAdat.HibaKtsg,
                        hibadatum = z.HibaAdat.HibaDatuma.ToString("yyyy-MM-dd"),
                        javaId = z.HibaAdat.KulsoId
                    })
                    .ToList();



                await kuld.HibaKuldPyhton(adatokPythonnak, "http://127.0.0.1:5000/hiba");

                querys.HibaKuldesJava();

                try
                {
                    var lista = await kuldjava.JavaKuldFogad(querys.HibaKuldesJava());



                    await kuldjava.KapottJavitasElment(lista);


                    var javitaslista = db.Gepek.Where(x => x.Hibak.Any()).Include(x => x.Hibak).ThenInclude(x => x.Javitas).ToList();


                    foreach (var sor in javitaslista.SelectMany(x => x.Hibak).GroupBy(x => x.Javitas).Select(x => new { javitas = x.Key }).ToList())
                    {
                        Console.WriteLine($"ID: {sor.javitas.Id} \n | Dátum: {sor.javitas.JavtiasDatum} \n |  Hibaid:{sor.javitas.HibaId} \n" +
                            $"| javitásktsg: {sor.javitas.JavitasKtsg} \n |  Szerelo {sor.javitas.Szerelo} \n | munkaber: {sor.javitas.Munkaber} \n");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}

