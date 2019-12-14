using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.BLL.DTO;
using eCommerce.BLL.Interfaces;
using eCommerce.BLL.Services;
using eCommerce.Models;

namespace eCommerce.Controllers
{
    public class CreateProductController : Controller
    {
        public IProductService ProductService;

        public CreateProductController(IProductService ip)
        {
            this.ProductService = ip;
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(ProductViewModel product)
        {
            product.productId = ProductService.FindMaxId() + 1;
            ProductService.CreateProduct(new ProductDTO(product.productId,product.title,product.price,product.category,product.commentsEnabled));
            int rateId = ProductService.FindMaxIdRate() + 1;
            ProductService.CreateRate(new RateDTO(rateId,product.productId,product.rate));
            return RedirectToAction("AllProducts","MainPage");
        }
    }
}