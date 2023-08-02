
namespace NLayer.API.Infrastructure.Tools
{
    public class TokenUret
    {
      
        public static string Token()
        {
            HttpResponseMessage response;

             

           var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("branchcode", "100") ,
                        new KeyValuePair<string, string>("password", "1") ,
                        new KeyValuePair<string, string>("username", "testt") ,
                        new KeyValuePair<string, string>("dbname", "EKOLGRUPTEST") ,
                        new KeyValuePair<string, string>("dbuser", "TEMELSET") ,
                        new KeyValuePair<string, string>("dbpassword", "") ,
                        new KeyValuePair<string, string>("dbtype", "0")
                    });

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(new Uri("http://10.10.35.33:7070"), "api/v2/token");
               

                response = client.PostAsync(client.BaseAddress.AbsoluteUri, formContent).Result;
            }

            var result = response.Content.ReadAsStringAsync().Result;

            response.Dispose();

            string asd = result.Split(',')[0];
            asd.Split(':');

            string token = asd.Split(':')[1].Trim('"');

            return token;
        }


    }
}

