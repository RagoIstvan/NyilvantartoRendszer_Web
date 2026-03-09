using MosogepBackend.Data;
using MosogepBackend.Enums;
using MosogepBackend.Models;
using MosogepBackend.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosogepBackend.Factorys
{
    public class HibaGenerator
    {
        Random rnd = new Random();

        public readonly Datadb _db;
        public readonly Kalkulator _kalkulator;

        public HibaGenerator(Datadb db, Kalkulator kalkulator)
        {
            _db = db;
            _kalkulator = kalkulator;
        }


        public Hiba EgyHibaGeneralasa(Mosogep gep)
        {

            Hibakod EgyHibakod = (Hibakod)rnd.Next(Enum.GetValues(typeof(Hibakod)).Length);

            Hiba randomhiba = new Hiba()
            {
                Hibakod = EgyHibakod,
                MosogepId = gep.Id,
                HibaKtsg = _kalkulator.HibaKoltsegKalkultaror(EgyHibakod),
                HibaDatuma = new DateTime(2025, 01, 01).AddDays(rnd.Next((new DateTime(2025, 12, 31) - new DateTime(2025, 01, 01)).Days + 1))

            };
            return randomhiba;

        }




        public void EgyHibaMentese()
        {

            var gepek = _db.Gepek.ToList();

            for (int i = 0; i < rnd.Next(35, 45); i++)
            {
                var randomgep = gepek[rnd.Next(gepek.Count())];

                randomgep.Hibak.Add(EgyHibaGeneralasa(randomgep));

                _db.SaveChanges();


            }




        }




    }
}
