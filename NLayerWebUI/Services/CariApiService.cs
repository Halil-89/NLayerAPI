using Newtonsoft.Json;
using NLayerWebUI.Models;

namespace NLayerWebUI.Services
{
    public class CariApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public CariApiService(HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }


        public async Task<List<CasabitViewModel>> GetCari()
        {

        
            var response = await _httpClient.GetAsync("http://localhost:5019/api/NetsisCari/CariList");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();


                dynamic datas = JsonConvert.DeserializeObject<dynamic>(jsonData);

                var resps = datas.Data;
                var x = ((IEnumerable<dynamic>)resps).Cast<dynamic>();


                var list = new List<CasabitViewModel>();

                foreach (var item in x)
                {

                    list.Add(new()
                    {
                        CARI_KOD = item.CariTemelBilgi.CARI_KOD,
                        CARI_ISIM = item.CariTemelBilgi.CARI_ISIM


                    });
                }
                return list;

            }

            return null;
        }
    }


}