using System.Text.Json.Nodes;

namespace MosogepBackend.Controller_Api
{
    public class ArfolyamSzamolApi
    {

        public readonly HttpClient _client;


        public ArfolyamSzamolApi(HttpClient client)
        {
            _client = client;
        }

        public static string Url = "https://api.exchangerate-api.com/v4/latest/EUR";




        public async Task<decimal> Arfolyamkeres(string url)
        {
            try
            {
                var adat = await _client.GetStringAsync(url);

                var jsonadat = JsonNode.Parse(adat);

                return jsonadat["rates"]["HUF"].GetValue<decimal>();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Hiba esetén {400} Ft térünk vissza!!!");
                return 400m;
            }




        }



    }
}
