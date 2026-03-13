using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace MosogepBackend.Models
{
    public class Javitas : ICloneable
    {


        public Javitas() { }

        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("javaid")]
        public int JavaJavitasId { get; set; }


        [JsonPropertyName("szerelo")]
        public string Szerelo { get; set; }

        [JsonPropertyName("datum")]
        public DateTime JavtiasDatum { get; set; }

        [JsonPropertyName("javitasktsg")]
        public int JavitasKtsg { get; set; }

        [JsonPropertyName("munkaber")]
        public int Munkaber { get; set; }

        [JsonPropertyName("nyereseg")]
        public int Nyereseg { get; set; }

        [JsonPropertyName("hibaid")]
        public int HibaId { get; set; }

        public Hiba Hiba { get; set; }
  
        public string JavitasSorszam { get { return $"Javit-00{JavaJavitasId}"; } }


        public override string ToString()
        {
            return $"\n--------------------------------------------------------------\n"
           + $"JavításSorszama:{JavitasSorszam}\n" +
            $"HibaSorszama: {Hiba.Sorszam}\n" +
            $"Szerelő: {Szerelo} \n" +
            $"Javításdátuma: {JavtiasDatum.ToString("yyyy.MM.dd")}\n" +
            $"HibaDáutam: {Hiba.HibaDatuma.ToString("yyyy.MM.dd")}\n" +
            $"-------------------------------\n" +
            $"Javitaskoltseg:{JavitasKtsg:N0} Ft\n" +
            $"- Munkbér: {Munkaber:N0} Ft\n" +
            $"- Hibakoltseg: {Hiba.HibaKtsg:N0} Ft\n" +
            $"= Nyereség: {Nyereseg:N0} Ft\n" +
     $"\n--------------------------------------------------------------\n";
        }


        public object Clone()
        {
         return   this.MemberwiseClone();
        }
    }
}
