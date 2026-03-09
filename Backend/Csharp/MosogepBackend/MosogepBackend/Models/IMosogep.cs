using MosogepBackend.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosogepBackend.Models
{
    public interface IMosogep
    {

        public int MaxToltotomeg { get; set; }

        public int MaxFordulat { get; set; }

        public double VizFelhasznalas(MosogepProgram program, double tomeg);


    }
}
