using MosogepBackend.Models;

namespace MosogepBackend
{
    public class Gyarto : ICloneable
    {


        public int Id { get; set; }

        public Gyarto() { }


        public List<Mosogep> Gepek { get; set; }=new List<Mosogep>();



        public Gyarto(string nev)
        {
            Nev = nev ?? throw new ArgumentNullException(nameof(nev));
        }

        private Gyarto(string nev, bool nepszeru):this(nev)
        {
            Nev = nev ?? throw new ArgumentNullException(nameof(nev));
            Nepszeru = nepszeru;
        }

        public string Nev { get; set; }
        public bool Nepszeru { get; private set; }




        public List<Gyarto> Getall() 
        {

            return GYARTOK.ToList();
        }



        private static List<Gyarto> GYARTOK = new List<Gyarto>()
        {
            new Gyarto("Philips", true),
            new Gyarto("AEG", true),
            new Gyarto("Candy", false),
            new Gyarto("LG", true),
            new Gyarto("Phicolo", false),
            new Gyarto("Electrolux", true),
            new Gyarto("Beko", false)
        };



        public override string ToString()
        {
            return Nev;
        }


        public object Clone()
        {
         return   this.MemberwiseClone();
        }
    }
}
