using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Infrastructure.Tools;

namespace NLayerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class NetsisStokController : ControllerBase

    {

        [HttpGet("[action]")]
        public IActionResult StokList()
        {


            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(new Uri("http://10.10.35.33:7070"), "api/v2/Items");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenUret.Token());


                response = client.GetAsync(client.BaseAddress.AbsoluteUri).Result;
            }

            var result = response.Content.ReadAsStringAsync().Result;

            response.Dispose();
            return Ok(result);
        }



    }


}

