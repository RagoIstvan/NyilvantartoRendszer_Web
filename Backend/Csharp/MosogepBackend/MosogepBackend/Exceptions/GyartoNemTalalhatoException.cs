using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MosogepBackend.Exceptions
{
    public class GyartoNemTalalhatoException:Exception
    {


        public GyartoNemTalalhatoException(string adat) 
            : base($" Adott Gyarto.Nev-vel {adat} nem található a támogaott mosogépek között.... ")
        {
        
        
        }


    }
}
