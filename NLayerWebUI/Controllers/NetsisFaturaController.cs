using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayerWebUI.Services;

namespace NLayerWebUI.Controllers
{
    [Authorize]
    public class NetsisFaturaController : Controller
    {
        private readonly NetsisTokenService _netsisTokenService;

        public NetsisFaturaController(NetsisTokenService netsisTokenService)
        {
            _netsisTokenService = netsisTokenService;
        }

        public IActionResult Index()
        {
            return View();
        }



    }
}
