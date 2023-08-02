namespace NLayerWebUI.Services
{
    public class NetsisTokenService
    {
        private readonly HttpClient _httpClient;

        public NetsisTokenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> NetsisToken()
        {
            var response = await _httpClient.GetAsync("http://localhost:5019/api/Token/NetsisToken");

            string token = await response.Content.ReadAsStringAsync();

            return token;



        }
    }
}
