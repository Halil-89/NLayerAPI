using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NLayerWebUI.Context;
using NLayerWebUI.Models;
using NLayerWebUI.NetsisEntity;
using NLayerWebUI.Services;
using System.Text;


namespace NLayerWebUI.Controllers
{
    [Authorize]
    public class FaturaController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly CariApiService _cariApiService;
        private readonly StokApiServis _stokApiService;
        private readonly NetsisTokenService _netsisTokenService;
        private readonly MyDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;



        public FaturaController(CariApiService cariApiService, StokApiServis stokApiService, NetsisTokenService netsisTokenService, MyDbContext context, HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {


            _cariApiService = cariApiService;
            _stokApiService = stokApiService;
            _netsisTokenService = netsisTokenService;
            _context = context;
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync("http://localhost:5019/api/NetsisCari/CariList");


            }
            return View();


        }

        public async Task<IActionResult> Dinamik()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

           // var netsistoken = await _netsisTokenService.NetsisToken();

        

            var response = await client.GetAsync("http://localhost:5019/api/NetsisCari/CariList");
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


            List<SelectListItem> statelist = new List<SelectListItem>();
            foreach (var item in list)
            {
                statelist.Add(new SelectListItem
                {
                    Text = item.CARI_KOD + " " + item.CARI_ISIM,
                    Value = item.CARI_KOD,
                });
            }



            var responsestok = await client.GetAsync("http://localhost:5019/api/NetsisStok/StokList");
            var jsonDatastok = await responsestok.Content.ReadAsStringAsync();

            dynamic datastok = JsonConvert.DeserializeObject<dynamic>(jsonDatastok);

            var respstok = datastok.Data;
            var xstok = ((IEnumerable<dynamic>)respstok).Cast<dynamic>();

            var liststok = new List<StokViewModel>();

            foreach (var item in xstok)
            {

                liststok.Add(new()
                {
                    STOK_KODU = item.StokTemelBilgi.Stok_Kodu,
                    STOK_ADI = item.StokTemelBilgi.Stok_Adi


                });
            }


            List<SelectListItem> stok = new List<SelectListItem>();
            foreach (var item in liststok)
            {
                stok.Add(new SelectListItem
                {
                    Text = item.STOK_KODU + " " + item.STOK_ADI,
                    Value = item.STOK_KODU,
                });
            }

            FaturaKalemModelView model = new FaturaKalemModelView();
            model.FaturaUsts = _context.FaturaUsts.Include(x => x.FaturaKalems).ToList();

            ViewBag.stoklist = stok;

            ViewBag.carilist = statelist;


            return View(model);

        }




        public async Task<ActionResult> FaturaKaydet(string FaturaSeriNo, string CariKodu, NetsisFaturaKalem[] kalemler)
        {
            HttpResponseMessage response;

            NetsisFatura fatura = new NetsisFatura();

            fatura.FatUst = new NetsisFaturaUst();
            fatura.FatUst.FATIRS_NO = FaturaSeriNo;
            fatura.FatUst.CariKod = CariKodu;
            fatura.FatUst.Tarih = DateTime.Now.ToString();
            fatura.FatUst.Tip = 0;
            fatura.FatUst.TIPI = 2;
            fatura.FatUst.KDV_DAHILMI = true;
            fatura.FatUst.SIPARIS_TEST = DateTime.Now.ToString();

            fatura.KayitliNumaraOtomatikGuncellensin = true;
            fatura.EPostaGonderilsin = false;
            fatura.KayitliNumaraOtomatikGuncellensin = true;
            fatura.EPostaGonderilsin = false;

            fatura.Kalems = new List<NetsisFaturaKalem>();

            NetsisFaturaKalem fatkalem = new NetsisFaturaKalem();

            foreach (var item in kalemler)
            {
                fatkalem.StokKodu = item.StokKodu;
                fatkalem.STra_NF = item.STra_NF;
                fatkalem.STra_BF = item.STra_NF;
                fatkalem.DEPO_KODU = 1;
                fatkalem.STra_GCMIK = item.STra_GCMIK;
                fatura.Kalems.Add(fatkalem);

            }

            var jsonval = JsonConvert.SerializeObject(fatura);

            var content = new StringContent(jsonval, Encoding.UTF8, "application/json");

            var token = await _netsisTokenService.NetsisToken();




            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(new Uri("http://10.10.35.33:7070"), "api/v2/ItemSlips");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                response = client.PostAsync(client.BaseAddress.AbsoluteUri, content).Result;

            }

            var result = response.Content.ReadAsStringAsync().Result;

            response.Dispose();


            return RedirectToAction("Index", "Home");

        }



    }
}

