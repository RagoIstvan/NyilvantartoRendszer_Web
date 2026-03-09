using System;
using System.Collections.Generic;
using System.Text;
using MosogepBackend.Exceptions;
using MosogepBackend.Models;

namespace MosogepBackend.Services
{
    public class Ellenorzes
    {

        public Gyarto GyartoEllenorzese(string adat) 
        {
        
        var gyarto=Gyarto.Getall().FirstOrDefault(x=>x.Nev==adat);

            if (gyarto == null) throw new GyartoNemTalalhatoException(adat);

            return gyarto;  
        
        
        }


        public Mosogep MosogepEllenorzes(string adat, string tipus, int tomeg, int fordulat)
        {

            var gyarto = GyartoEllenorzese(adat);

            if (string.IsNullOrEmpty(tipus)) throw new Exception("Hiba nem lehet a tipus üres");

            if (tomeg < 5) throw new Exception("hiba nem lehet a tömeg kisebb mint 5");
            if (tomeg > 11) throw new NagyMaximalisToltotomegException(tomeg);

            if (fordulat < 800) throw new Exception("Hiba nem lehet a fordulat kisebb mint 800");
            if (fordulat > 1400) throw new Exception("hiba nem lehet a fordulat nagyobb mint 1400");
            if(fordulat%100!=0) throw new MaximalisFordulatszamNemErvenyesException(fordulat);

            var gep=new Mosogep(gyarto,tipus,tomeg,fordulat);

            return gep;

        }



        public User UserEllenorzes(string nev, string email, string password)
        {

            if (string.IsNullOrEmpty(nev)) throw new Exception("Hiba nem lehet a név üres");

            if (!(email.Contains("@"))) throw new Exception("hiba az amielnek kell tartalmaznia @");

            if (password.Length < 7) throw new Exception("A jelszó nem lehet 7 rövidebb");

            var user = new User(nev, email, password);

            return user;
        
        
        
        }






    }
}
