using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Infrastructure.Tools;
using NLayerWebUI.Services;

namespace NLayerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class NetsisCariController : ControllerBase
    {
     

        [HttpGet("[action]")]
        public IActionResult CariListId()
        {
            string id = "OK000000000004";

            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(new Uri("http://10.10.35.33:7070"), $"api/v2/ARPs/{id}");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenUret.Token());

                 response = client.GetAsync(client.BaseAddress.AbsoluteUri).Result;
            }

            var result = response.Content.ReadAsStringAsync().Result;

            //var data = JsonSerializer.Serialize(result);

            response.Dispose();
            return Ok(result);
        }


        [HttpGet("[action]")]
        public IActionResult CariList()
        {


            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
              
                client.BaseAddress = new Uri(new Uri("http://10.10.35.33:7070"), $"api/v2/ARPs");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenUret.Token());


                response = client.GetAsync(client.BaseAddress.AbsoluteUri).Result;
            }

            var result = response.Content.ReadAsStringAsync().Result;


            response.Dispose();
            return Ok(result);
        }



    }




}
