using Models;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;

namespace APICarro.Services
{
    public class CarroService
    {
        private static readonly HttpClient _httpCliente = new HttpClient();

        public async Task<Carro> PostCarro(Carro carro)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(carro), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await CarroService._httpCliente.PostAsync("https://localhost:5005/api/Carro", content);
                response.EnsureSuccessStatusCode();
                string carroReturn = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Carro>(carroReturn);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
