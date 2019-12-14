namespace eCommerce.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Microsoft.AspNet.Identity.Owin;
    using PagedList.Mvc;
    using PagedList;
    using eCommerce.BLL.DTO;
    using eCommerce.BLL.Infrastructure;
    using eCommerce.BLL.Interfaces;
    using eCommerce.BLL.Services;
    using eCommerce.Models;
    public class MainPageController : Controller
    {
        private IProductService productService;

        public MainPageController(IProductService iserv)
        {
            this.productService = iserv;
        }
        public ActionResult MainPage(int? page, string sortOrder, string Category, string maxPrice)
        {
            //ViewBag.CurrentSort = sortOrder;
            //ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            //ViewBag.PriceSortParm = (sortOrder == "Price" )? "price_desc" : "";
            //ViewBag.CategorySortParm = (sortOrder == "Category" )? "category_desc" : "";
            //ViewBag.RateSortParm = (sortOrder == "Rate") ? "rate_desc" : "";

            IEnumerable<ProductDTO> p = this.productService.GetAll();
            IEnumerable<RateDTO> rates = this.productService.GetAllRates();
            var rates_grouped = from r in rates
                                group r by r.productId
                                into rates_
                                select new { product_id = rates_.Key, rate = rates_.Sum(e => e.rate1) / rates_.Count() };


            IEnumerable<ProductViewModel> products = (from i in p
                                                      join r in rates_grouped
                                                      on i.productId equals r.product_id
                                                      select new ProductViewModel(i, r.rate));

            var categories = new SelectList((from i in products
                                             orderby i.category
                                             select i.category).Distinct().ToList());
            ViewBag.Category = categories;



            if (!string.IsNullOrEmpty(Category))
            {
                products = products.Where(x => x.category == Category);
            }

            double price;
            if (double.TryParse(maxPrice, out price))
            {
                products = products.Where(x => x.price <= price);
            }
            switch (sortOrder)
            {
                case "title_desc":
                    products = products.OrderBy(s => s.title);
                    break;
                case "price_desc":
                    products = products.OrderBy(s => s.price);
                    break;
                case "category_desc":
                    products = products.OrderBy(s => s.category);
                    break;
                case "rate_desc":
                    products = products.OrderBy(s => s.rate);
                    break;
                default:
                    products = products.OrderByDescending(s => s.price);
                    break;
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult MainPageAdmin()
        {
            if (this.Session["isAdmin"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            return this.View();
        }
        public ActionResult AllProducts()
        {
            IEnumerable<ProductDTO> products = this.productService.GetAll();

            return this.View(products);
        }
        public ActionResult DeleteProduct(int id)
        {
            var allComentsToThisProduct = this.productService.GetAllComments().Where(e => e.productId == id);
            foreach (var item in allComentsToThisProduct)
            {
                this.productService.DisposeComment(item.commentId);
            }
            var allOrdersToThisProduct = this.productService.GetAllOrders().Where(e => e.productId == id);
            foreach (var item in allOrdersToThisProduct)
            {
                this.productService.DisposeOrder(item.orderId);
            }
            this.productService.Dispose(id);

            return this.RedirectToAction("AllProducts", "MainPage");
        }
        public ActionResult EditProduct(int id)
        {
            var product = this.productService.GetById(id);
            return this.View(product);
        }
        public ActionResult EditProduct(ProductDTO product)
        {
           // var product = this.productService.GetById(id);
            return this.View(product);
        }
    }
}