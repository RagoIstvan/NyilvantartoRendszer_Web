using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosogepBackend.Models
{
    public abstract class Nagygep:IComparable<Nagygep>,ICloneable
    {


        public int Id { get; set; }

        public Nagygep() { }

        public int GyartoId { get; set; }


        protected Nagygep(Gyarto gyarto, string tipus)
        {
            Gyarto = gyarto;
            Tipus = tipus ?? throw new ArgumentNullException(nameof(tipus));
        }

        public Gyarto Gyarto { get; set; }
        public string Tipus { get; private set; }





        public abstract int Relevencia { get; }

        public abstract double Hatekonysag();



        public abstract object Clone();

        public int CompareTo(Nagygep? other)
        {
            if (other == this) return 0;

            if (other == null) throw new Exception("Nem lehet null érték...");

            int ertek = other.Relevencia.CompareTo(this.Relevencia);

            if (ertek != null) return ertek;

            else return other.Hatekonysag().CompareTo(this.Hatekonysag());


        }

        public override bool Equals(object? obj)
        {
            if (obj == this) return true;
            if (obj == null || obj is not Nagygep uj) return false;


            return uj.Gyarto.Nev==this.Gyarto.Nev && uj.Tipus==this.Tipus;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Gyarto.Nev, Tipus);
        }


        //public override string ToString()
        //{
        //    return $"{Gyarto} {Tipus}, {Relevancia}, {Hatekonysag() * 100}%";
        //}
    }
}
