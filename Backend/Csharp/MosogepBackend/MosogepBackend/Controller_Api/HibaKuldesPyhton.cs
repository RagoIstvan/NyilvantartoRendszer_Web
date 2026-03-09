using System.Text;
using System.Text.Json;

namespace MosogepBackend.Controller_Api
{
    public class HibaKuldesPyhton
    {


        public readonly HttpClient _client;


        public HibaKuldesPyhton(HttpClient client)
        {

            _client = client;

        }




        public async Task HibaKuldPyhton(object data,string vegpont)
        {
            try
            {

                var adat = JsonSerializer.Serialize(data);


                var jsonadat = new StringContent(adat, Encoding.UTF8, "application/json");


                var response = await _client.PostAsync($"{vegpont}", jsonadat);


                response.EnsureSuccessStatusCode();


                var read = await response.Content.ReadAsStringAsync();


                Console.WriteLine($"A Python válaszas: {read}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }




    }
}
