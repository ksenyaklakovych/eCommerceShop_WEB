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
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "";

            IEnumerable<ProductDTO> products = this.productService.GetAll();

            var categories = new SelectList((from i in products
                                             orderby i.category
                                             select i.category).Distinct().ToList());

            ViewBag.Category = categories;
            switch (sortOrder)
            {
                case "title_desc":
                    products = products.OrderBy(s => s.title);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.price);
                    break;
                case "category_desc":
                    products = products.OrderByDescending(s => s.category);
                    break;
                default:  // price ascending 
                    products = products.OrderBy(s => s.price);
                    break;
            }


            if (!string.IsNullOrEmpty(Category))
            {
                products = products.Where(x => x.category == Category);
            }

            double price;
            if (double.TryParse(maxPrice, out price))
            {
                products = products.Where(x => x.price <= price);
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        } 
        public ActionResult MainPageAdmin()
        {
            if (this.Session["isAdmin"]==null)
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

    }
}