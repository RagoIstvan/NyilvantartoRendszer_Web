using Microsoft.EntityFrameworkCore;
using MosogepBackend.Data;
using MosogepBackend.Event;
using MosogepBackend.Models;
using System.Text;
using System.Text.Json;

namespace MosogepBackend.Controller_Api
{
    public class KommunikacioJava
    {

        private readonly HttpClient _httclient;
        private readonly Datadb _db;
        public KommunikacioJava(HttpClient httclient, Datadb datadb)
        {
            _httclient = httclient;
            _db = datadb;
        }

        public async Task<List<Javitas>> JavaKuldFogad(object data)
        {


            try
            {
                if (data != null)
                {
                    var adat = JsonSerializer.Serialize(data);

                    var jsonadat = new StringContent(adat, Encoding.UTF8, "application/json");


                    var response = await _httclient.PostAsync("http://localhost:8080/java/hiba", jsonadat);

                    response.EnsureSuccessStatusCode();


                    var read = await response.Content.ReadAsStringAsync();


                    var stringadat = JsonSerializer.Deserialize<List<Javitas>>(read, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


                    return stringadat;
                }
                else { return new List<Javitas>(); }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);

                return new List<Javitas>();
            }
        }




        public async Task KapottJavitasElment(List<Javitas> adat)
        {


            if (adat == null)
            {
                Console.WriteLine("A lista üres valami nem jól lett átadva");
            }

            try
            {
                _db.ChangeTracker.Clear();


                foreach (var j in adat)
                {

                    //j.HibaId = j.Hiba.KulsoId;



                    // EN: Reset IDs to save them as new records in the database
                    j.Id = 0;
                    j.Hiba = null;
                }



                _db.Javitas.AddRange(adat);



                await _db.SaveChangesAsync();



                Console.WriteLine($"✅ {adat.Count} db javítás elmentve az adatbázisba.");




                var mentettJavitasok = await _db.Javitas.Include(j => j.Hiba).ToListAsync();

                foreach (var j in mentettJavitasok)
                {
                    await NaploEven.EsemenyMetodus(j);
                    //Console.WriteLine($"Mentett DB ID: {j.Id} | Hiba ID: {j.HibaId} | Szerelő: {j.Szerelo,-15} | Költség: {j.JavitasKtsg:N0} Ft");
                }
                Console.WriteLine("=============================================\n");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }

        }










    }






}

