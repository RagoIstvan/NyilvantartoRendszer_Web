using MosogepBackend.Data;
using MosogepBackend.Exceptions;
using MosogepBackend.Models;
using MosogepBackend.Services;
using System.Runtime.CompilerServices;

namespace MosogepBackend.Factorys
{


    public class RandomGyartas
    {
        Random rnd = new Random();

        public readonly decimal _arfolyam;
        public readonly Kalkulator _kalkulator;
        public readonly Ellenorzes _ellenorzes;
        public readonly Datadb _db;


        public RandomGyartas(decimal arfolyam, Kalkulator kalkulator, Ellenorzes ellenorzes, Datadb db)
        {
            _arfolyam = arfolyam;
            _kalkulator = kalkulator;
            _ellenorzes = ellenorzes;
            _db = db;


        }

        public string GyartoGeneral()
        {
            var gyarto = Gyarto.Getall()[rnd.Next(Gyarto.Getall().Count())];

            return gyarto.Nev;

        }


        public string TipusGeneral()
        {

            char[] tipus = new char[12];

            for (int i = 0; i < tipus.Length; i++)
            {

                if (i % 2 == 0)
                {
                    tipus[i] = (char)rnd.Next('A', 'Z' + 1);

                }
                else
                {
                    tipus[i] = (char)rnd.Next('0', '9' + 1);

                }
            }


            return new string(tipus);


        }



        public int TomegGeneral()
        {
            return rnd.Next(5, 11);

        }




        public int FordulatGeneral()
        {

            return rnd.Next(800, 1400) / 100 * 100;





        }




        public User UserGeneral()
        {

            int index = _db.User.Count();

            var user = _db.User.Skip(rnd.Next(index)).FirstOrDefault();

            return user;



        }



        public void MosogepGeneral(User user)
        {

            try
            {
                for (int i = 0; i < rnd.Next(35, 45); i++)
                {

                    var gep = _ellenorzes.MosogepEllenorzes(GyartoGeneral(), TipusGeneral(), TomegGeneral(), FordulatGeneral());


                    gep.Azonosito = "DLL";
                    gep._User = user;
                    gep.UserId = user.Id;
                    gep.GepAraEuro = _kalkulator.GepAraEuroKalkulator(gep);
                    gep.GepAraFt = _kalkulator.GepAraFtKalkulator(_arfolyam, gep.GepAraEuro);

                    _db.Gepek.Add(gep);


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            _db.SaveChanges();
        }

    }

}










