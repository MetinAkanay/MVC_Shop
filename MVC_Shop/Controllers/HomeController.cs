using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Shop.DMO;
using MVC_Shop.Models;
using MVC_Shop.Models.DTO;
using MVC_Shop.Models.ViewModel;
using MVC_Shop.Service;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MVC_Shop.Controllers
{
    public class HomeController : Controller
    {
        private IProductCategoryService _productSubCategoryService;
        private IProductService _productService;
        private IBasketService _basketService;

        public HomeController(IProductCategoryService productSubCategoryService, IProductService productService, IBasketService basketService)
        {
            _productSubCategoryService = productSubCategoryService;
            _productService = productService;
            _basketService = basketService;
        }

        public IActionResult Index()
        {
            PscViewModel model = new PscViewModel();
            model.PSCModel = _productSubCategoryService.GetAll();
            return View(model);
        }

        public IActionResult ProductFilter(int categoryId)
        {
            PscViewModel model = new PscViewModel();
            model.PSCModel = _productSubCategoryService.GetAll();
            model.Products = _productService.GetProductBySubCategoryId(categoryId);

            // sayfa refresh oldu�unda, sepetteki �r�n miktar� s�f�rlan�yor d�zeltelim.

            // sepette �r�n varsa �r�n say�s�n� bulal�m.
            if(HttpContext.Session.GetString("sepet") != null)
            {
                string json = HttpContext.Session.GetString("sepet");
                var sessionObject = JsonConvert.DeserializeObject<List<int>>(json);
                
                // session i�erisindeki �r�n adedini bulup, view modele mapledik
                model.SessionCount = sessionObject.Count;
                 
            }

            return View("Index", model);
        }

        public IActionResult Sepet()
        {
            //�nce sepette olan �r�nleri �d de�erlerini yakalayal�m
            if (HttpContext.Session.Keys.Count()> 0)
            {
                var jsonBasket = HttpContext.Session.GetString("sepet");

                List<int> basketIds = JsonConvert.DeserializeObject<List<int>>(jsonBasket);
                var baskets = _basketService.GetProductById(basketIds);

                return View(baskets);
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult AddSepet(int Id)
        {
            try
            {
                if (HttpContext.Session.GetString("sepet") != null && HttpContext.Session.Keys.Count()>0)
                {
                    // �kinci kez session' � kullan�yorsak
                    var sepetList = JsonConvert.DeserializeObject<List<int>>(HttpContext.Session.GetString("sepet"));
                    sepetList.Add(Id);

                    var jsonsepet = JsonConvert.SerializeObject(sepetList);
                    HttpContext.Session.SetString("sepet", jsonsepet);

                }
                else
                {
                    // �lk kez kullan�yorsak
                    List<int> sepets = new List<int> { Id };
                    var jsonsepet = JsonConvert.SerializeObject(sepets);
                    HttpContext.Session.SetString("sepet", jsonsepet);

                }
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
