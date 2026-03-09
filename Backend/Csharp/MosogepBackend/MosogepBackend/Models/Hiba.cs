using MosogepBackend.Enums;
using System.Text.Json.Serialization;

namespace MosogepBackend.Models
{
    public class Hiba : ICloneable
    {

        public Hiba() { }


        [JsonPropertyName("id")]
        public int Id { get; set; }

        public string Sorszam { get { return $"Hiba-00{Id}"; } }

        [JsonPropertyName("kulsoId")]
        public int KulsoId { get; set; }

        public int MosogepId { get; set; }


        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("hibakod")]
        public Hibakod Hibakod { get; set; }

        public int HibaKodSzama
        {
            get
            {
                int ertek = Hibakod switch
                {
                    Hibakod.MotorHiba => 404,
                    Hibakod.SzivattyuHiba => 402,
                    Hibakod.FutesiHiba => 401,
                    Hibakod.SzenzorHiba => 400,
                    Hibakod.VizellatasiHiba => 405,
                    _ => 0
                };
                return ertek;
            }
        }

        public string HibakodKiolvas()
        {
            return $"{Hibakod}-{HibaKodSzama}";
        }



        [JsonPropertyName("hibaktsg")]
        public int HibaKtsg { get; set; }

        [JsonPropertyName("hibadatum")]
        public DateTime HibaDatuma { get; set; }


        public Javitas Javitas { get; set; }



        public override string ToString()
        {
            return $"\n--------------------------------------------------------------\n" +
            $"id: {Id} \n" +
            $"Sorszam: {Sorszam} \n" +
            $"hibakod: {HibakodKiolvas()} \n" +
            $"Hibadátuma: {HibaDatuma.ToString("yyyy.MM.dd")}\n" +
            $"Hibakoltsege: {HibaKtsg:N0} Ft \n" +
            $"\n--------------------------------------------------------------\n";
        }


        public object Clone()
        {
            Hiba klon = this.MemberwiseClone() as Hiba;

            klon.Javitas = Javitas.Clone() as Javitas;

            return klon;
        }
    }
}
