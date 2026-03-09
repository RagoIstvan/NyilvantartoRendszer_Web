using MosogepBackend.Data;
using MosogepBackend.Models;

namespace MosogepBackend.Services
{
    public class CsvReader
    {
        public readonly decimal _arfolyam;
        public readonly Kalkulator _kalkulator;
        public readonly Ellenorzes _ellenorzes;
        public readonly Datadb _db;


        public CsvReader(decimal arfolyam, Kalkulator kalkulator, Ellenorzes ellenorzes, Datadb db)
        {
            _arfolyam = arfolyam;
            _kalkulator = kalkulator;
            _ellenorzes = ellenorzes;
            _db = db;


        }



        public void Reader(User user)
        {
            try
            {

                string[] adatfile = File.ReadAllLines("mosogepek.csv");

                foreach (var sor in adatfile)
                {
                    try
                    {
                        string[] sorok = sor.Split(";");


                        var gep = _ellenorzes.MosogepEllenorzes(sorok[0], sorok[1], int.Parse(sorok[2]), int.Parse(sorok[3]));

                        gep._User = user;
                        gep.UserId = user.Id;
                        gep.GepAraEuro = _kalkulator.GepAraEuroKalkulator(gep);
                        gep.GepAraFt = _kalkulator.GepAraFtKalkulator(_arfolyam, gep.GepAraEuro);
                        gep.Azonosito = "CSV";

                        _db.Gepek.Add(gep);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }


                _db.SaveChanges();

            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);

            }

        }









    }
}
