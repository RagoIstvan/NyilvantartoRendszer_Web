using MosogepBackend.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosogepBackend.Models
{
    public class JavitasNaplo:ICloneable
    {

        public int Id { get; set; }

        public JavitasNaplo() { }

        public int JatitasKtsg { get; set; }

        public string Szerelo { get; set; }

        public Hibakod Hibakod { get; set; }


        public DateTime FeliratkozasDatuma { get; set; }



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
