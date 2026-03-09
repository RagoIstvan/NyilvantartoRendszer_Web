using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MosogepBackend.Data;
using MosogepBackend.Models;

namespace MosogepBackend.Querys_Linq
{
    public class QuerysFails
    {

        public readonly Datadb _db;


        public QuerysFails(Datadb db) 
        {
        _db= db;    
        }


        public object HibakLekerdezese() 
        {

            var hibak = _db.Gepek.Where(x => x.Hibak.Any())
                               .SelectMany(x => x.Hibak, (GepNev, GepHiba) => new { gep = GepNev.Gyarto.Nev, hibakod = GepHiba.Hibakod.ToString(), hiba=GepHiba })
                               .GroupBy(x=> new {x.gep,  x.hibakod })
                               .Select(x => new { gep = x.Key, ktsg = x.Sum(c => c.hiba.HibaKtsg), db = x.Count() })
                               .OrderBy(x => x.gep.gep)
                               .ToList();


            foreach (var sor in hibak)
            {
                Console.WriteLine($"{sor.gep.gep} | {sor.gep.hibakod}   | {sor.db} db | {sor.ktsg:N0} Ft");
            }

            return hibak;


        }






    }
}
