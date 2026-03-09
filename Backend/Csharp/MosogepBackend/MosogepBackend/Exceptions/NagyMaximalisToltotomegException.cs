namespace MosogepBackend.Exceptions
{
    public class NagyMaximalisToltotomegException : Exception
    {

        public readonly int ertek;


        public NagyMaximalisToltotomegException(int adat)
            : base($"Rossz beviteli adat lett megadva .... {adat} 5 - 11 kg között kell legyen a tömeg...")


        {

            ertek = adat;
        }


    }
}
