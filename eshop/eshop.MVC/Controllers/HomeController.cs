﻿using eshop.Application.Services;
using eshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eshop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            /*
             * Burada değişiklik yapmak için karşılaşabileceğiniz çok sebep var
             *  1. Yeni bir ürün özelliği
             *  2. Ürünlerin nereden geleceği (db, api, excel)
             *  3. Ürünlerin nasıl geleceği (EF, ADO, HttpClient vs)
             *  
             */
            //var productService = new  ProductService();
            var products = _productService.GetProductCardResponses();
            return View(products);
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
