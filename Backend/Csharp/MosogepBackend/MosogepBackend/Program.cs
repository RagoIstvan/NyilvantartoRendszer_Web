using Microsoft.EntityFrameworkCore;
using MosogepBackend.Models;

namespace MosogepBackend
{
    public class Program
    {
        static void Main(string[] args)
        {


            try
            {
                var ujGep = new Mosogep(new Gyarto("LG"), "1258GHJ", 7, 1500);
                var ujUser = new User("Teszt", "12564", "A@.hu");
                ujGep.Azonosito = "Dll";
                ujGep._User=ujUser;
                ujGep.UserId = ujUser.Id;

                Data.Datadb uj = new Data.Datadb();
                Console.WriteLine($"FIGYELEM! A program ezt az adatbázist használja: {uj.Database.GetDbConnection().DataSource}");

                uj.Gepek.Add(ujGep);
                uj.User.Add(ujUser);


                // 3. A fizikai mentés! (Itt kapják meg az adatbázistól az ID-t)
                uj.SaveChanges();

                // 4. Ellenőrzés
                Console.WriteLine($"Sikeres mentés az adatbázisba!");
                Console.WriteLine($"Új gép azonosítója: {ujGep.Id}");
                Console.WriteLine($"Új user azonosítója: {ujUser.Id}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}

