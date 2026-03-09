using MosogepBackend.Enums;
using MosogepBackend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosogepBackend.Services
{
    public class Kalkulator
    {
        Random rnd = new Random();



        public int HibaKoltsegKalkultaror(Hibakod kod) 
        {

            int ertek = kod switch
            {
                Hibakod.MotorHiba => rnd.Next(50000, 150000),
                Hibakod.SzivattyuHiba => rnd.Next(30000, 120000),
                Hibakod.FutesiHiba => rnd.Next(80000, 140000),
                Hibakod.SzenzorHiba => rnd.Next(10000, 100000),
                Hibakod.VizellatasiHiba => rnd.Next(60000, 75000),
                _ => 15500
            };
            return ertek;
        
        }


        public int GepAraEuroKalkulator(Mosogep gep) 
        {

            int ertek = gep.Gyarto.Nev switch
            {
                "LG" => rnd.Next(1500, 2000),
                "Philips" => rnd.Next(1500, 2000),
                "AEG" => rnd.Next(1500, 2000),
                "Candy" => rnd.Next(1500, 2000),
                "Phicolo" => rnd.Next(1500, 2000),
                "Beko" => rnd.Next(1500, 2000),
                "Electrolux" => rnd.Next(1500, 2000),
                _ => 1850

            };
            return ertek;

        }



        public int GepAraFtKalkulator(decimal ertek, int GepAraEuro) 
        {


            return (int)ertek * GepAraEuro;
        
        }






    }
}
