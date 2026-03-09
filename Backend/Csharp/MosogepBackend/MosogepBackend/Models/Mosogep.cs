using MosogepBackend.Enums;
using MosogepBackend.Exceptions;

namespace MosogepBackend.Models
{
    public class Mosogep : Nagygep, IMosogep, ICloneable
    {

        Random rnd = new Random();
        

        public Mosogep() { }


        public int HibaId { get; set; }





        public Mosogep(Gyarto gyarto, string tipus, int Tomeg, int Fordulat) : base(gyarto, tipus)
        {
            MaxToltotomeg = Tomeg;
            MaxFordulat = Fordulat;

            Datum = new DateTime(2025, 01, 01).AddDays(rnd.Next((new DateTime(2025, 12, 31) - new DateTime(2025, 01, 31)).Days + 1));



        }


        public int UserId { get; set; }

        public List<Hiba> Hibak { get; set; } = new List<Hiba>();

        public User _User { get; set; }





        public DateTime Datum { get; set; }

        public int GepAraEuro { get; set; }

        public int GepAraFt { get; set; }

        public string Azonosito { get; set; }

        public int MaxToltotomeg { get; set; }
        public int MaxFordulat { get; set; }



        public override int Relevencia
        {
            get
            {
                double ertek = ((Hatekonysag() - 0.26) / 0.74 * 10);
                return (int)ertek;
            }
        }



        public override double Hatekonysag()
        {
            double ertek = (double)MaxFordulat * (double)MaxToltotomeg / 100;
            return ertek;
        }

        public double VizFelhasznalas(MosogepProgram program, double tomeg)
        {

            if (tomeg > 11) throw new NagyMaximalisToltotomegException((int)tomeg);

            else
            {
                double ertek = program switch
                {
                    MosogepProgram.GYAPJU => tomeg / 2,
                    MosogepProgram.ECO => tomeg / 1.5,
                    MosogepProgram.EXTRA => tomeg / 3,
                    MosogepProgram.CENTRIFUGA => 0,
                    _ => 0
                };
                return ertek;
            }
        }


        public override object Clone()
        {
            Mosogep klon = this.MemberwiseClone() as Mosogep;

            klon.Hibak = new List<Hiba>();

            foreach (var sor in Hibak)
            {
                klon.Hibak.Add(sor.Clone() as Hiba);
            }

            return klon;
        }




        public override string ToString()
        {
             return $"User: {_User}\n" +
                    $"{typeof(Mosogep).Name}\n" +
                    $"Gyarto:{Gyarto.Nev}\n" +
                    $"Tipus:{Tipus}\n" +
                    $"Népszerű:{(Gyarto.Nepszeru ? "igen" : "nem")}\n" +
                    $"Fordulat: {MaxFordulat}\n" +
                    $"Tomeg: {MaxToltotomeg}\n" +
                    $"Relevencia:{Relevencia} \n" +
                    $"Hatékonyság:{Hatekonysag():0.0}\n" +
                    $"GyártásDátum: {Datum.ToString("yyyy.MM.dd")}\n" +
                    $"Gépára: {GepAraEuro:N0} Euro \n" +
                    $"GépáraFt: {GepAraFt:N0} Ft\n" +
                    $"Hely: {Azonosito}\n";
        }
















    }
}
