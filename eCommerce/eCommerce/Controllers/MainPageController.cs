using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Models;
using PagedList;

namespace eCommerce.Controllers
{
    public class MainPageController : Controller
    {
        public ActionResult MainPage(int? page, string sortOrder, string Category, string maxPrice)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "";

            IEnumerable<Product> products;
            using (commerceShopDB dbModel = new commerceShopDB())
            {
                products = dbModel.Products.ToList();

            }
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
    }
}