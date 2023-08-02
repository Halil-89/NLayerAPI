using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayerWebUI.Services;

namespace NLayerWebUI.Controllers
{
    [Authorize]
    public class NetsisCariController : Controller
    {
        //private readonly IHttpClientFactory httpClientFactory;

        private readonly CariApiService _cariApiService;

        public NetsisCariController(CariApiService cariApiService)
        {

            _cariApiService = cariApiService;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> GetirHepsi()
        {
            var cariList = await _cariApiService.GetCari();


            return View(cariList);
        }



    }
}
