using MosogepBackend.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MosogepBackend.Models
{
    public class JavitasNaplo:ICloneable
    {

        [JsonPropertyName("csharpId")]
        public int Id { get; set; }

        public JavitasNaplo() { }


        [JsonPropertyName("javitasktsg")]
        public int JatitasKtsg { get; set; }


        [JsonPropertyName("szerelo")]
        public string Szerelo { get; set; }

        [JsonPropertyName("hibakod")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Hibakod Hibakod { get; set; }

        [JsonPropertyName("datum")]
        public DateTime FeliratkozasDatuma { get; set; }


        [JsonPropertyName("gep")]
        public string Gepadatai { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} \n" +
                $"Gepadatai: {Gepadatai} \n" +
                $"Datum: {FeliratkozasDatuma.ToString("yyyy.MM.dd")} \n" +
                $"Szerelo: {Szerelo}\n" +
                $"Hibakod: {Hibakod} \n" +
                $"Végösszeg: {JatitasKtsg:N0}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
