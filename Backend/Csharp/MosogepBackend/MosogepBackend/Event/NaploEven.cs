using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MosogepBackend.Data;
using MosogepBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace MosogepBackend.Event
{
    public class NaploEven
    {

        public readonly Datadb db;

        public NaploEven(Datadb db) { this.db = db; }


        public static event Func<Javitas, Task> EsemenyDelegate;



        public static async Task EsemenyMetodus(Javitas egyed) 
        {


            if (egyed.JavitasKtsg > 150000) 
            {
               await EsemenyDelegate?.Invoke(egyed);
            
            }
        
       
        
        }



        public  async Task NaploKiiras()
        {

             var naplozas = db.Naplo.ToList();


            foreach (var sor in naplozas)
            {
                Console.WriteLine(sor);
            }



        }

        public async Task<List<JavitasNaplo>> NaploKiiras2()
        {
            var naplozas = db.Naplo.ToList();

            foreach (var sor in naplozas)
            {
                Console.WriteLine(sor);
            }

            return naplozas; // Ezt a listát küldjük vissza!
        }




    }
}
