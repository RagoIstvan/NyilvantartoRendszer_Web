using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MosogepBackend.Models;

namespace MosogepBackend.Data
{
    public class Datadb:DbContext
    {

        public DbSet<Mosogep> Gepek { get; set; }

        public DbSet<Hiba> Hiba{ get; set; }

        public DbSet<Javitas> Javitas { get; set; }

        public DbSet<User> User{ get; set; }

        public DbSet<JavitasNaplo> Naplo { get; set; }
        public DbSet<Gyarto> Gyartok { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlite(@"Data Source=C:\Users\RagoIstvan\Desktop\NyilvantartoRendszer_Web\Web\Backend\Csharp\MosogepBackend\MosogepBackend\adatbazis.db");
        }





    }
}
