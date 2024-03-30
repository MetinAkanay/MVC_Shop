using Microsoft.AspNetCore.Mvc;
using MVC_Shop.Models;
using MVC_Shop.Models.ViewModel;
using MVC_Shop.Service;
using System.Diagnostics;

namespace MVC_Shop.Controllers
{
    public class HomeController : Controller
    {
        private IProductCategoryService _productSubCategoryService;
        private IProductService _productService;
        public HomeController(IProductCategoryService productSubCategoryService, IProductService productService)
        {
            _productSubCategoryService = productSubCategoryService;
            _productService = productService;
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

            return View("Index",model);
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
