using Microsoft.EntityFrameworkCore;
using MosogepBackend.Factorys;
using MosogepBackend.Models;
using MosogepBackend.Services;
using MosogepBackend;
using MosogepBackend.Controller_Api;

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


                // EN: Fetching live data before starting the main logic
                decimal arfolyam = await szamol.Arfolyamkeres(ArfolyamSzamolApi.Url);


                Ellenorzes ujellenorzes = new Ellenorzes();  
                RandomGyartas gyartas = new RandomGyartas(arfolyam, kalkulator, ujellenorzes, db);
                CsvReader reader = new CsvReader(arfolyam, kalkulator,ujellenorzes,db);



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

                var rosszGepek = db.Gepek
                                .Include(m => m.Hibak)
                                .Include(m => m.Gyarto)
                                .Where(x => x.Hibak.Any())
                                .ToList();

                foreach (var gep in rosszGepek)
                {
                    var aktualisHiba = gep.Hibak.LastOrDefault();

                    Console.WriteLine($"{gep.Azonosito} \n {aktualisHiba}");
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

