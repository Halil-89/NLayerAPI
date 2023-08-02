using Newtonsoft.Json;
using NLayerWebUI.Models;

namespace NLayerWebUI.Services
{
    public class StokApiServis
    {
        private readonly HttpClient _httpClient;

        public StokApiServis(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StokViewModel>> GetStok()
        {
            var response = await _httpClient.GetAsync("http://localhost:5019/api/NetsisStok/StokList");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();


                dynamic datas = JsonConvert.DeserializeObject<dynamic>(jsonData);

                var resps = datas.Data;
                var x = ((IEnumerable<dynamic>)resps).Cast<dynamic>();


                var list = new List<StokViewModel>();

                foreach (var item in x)
                {

                    list.Add(new()
                    {
                        STOK_KODU = item.StokTemelBilgi.Stok_Kodu,
                        STOK_ADI = item.StokTemelBilgi.Stok_Adi

                    });
                }
                return list;

            }

            return null;
        }
    }
}
