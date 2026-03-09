namespace MosogepBackend.Exceptions
{
    public class MaximalisFordulatszamNemErvenyesException : Exception
    {


        public readonly int ertek;


        public MaximalisFordulatszamNemErvenyesException(int adat)
            : base($"Nem jól adtad meg a beviteli adatot {adat} \n 800 és 1400 között kell lennie és egész értéknek...")
        {
            ertek = adat;
        }



    }
}
