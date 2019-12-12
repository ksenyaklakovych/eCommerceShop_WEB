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

namespace eCommerce.Controllers
{
    public class DetailController : Controller
    {
        private IProductService productService;

        public DetailController(IProductService serv)
        {
            this.productService = serv;
        }

        public ActionResult ProductDetail(int Id)
        {
            var prod = (productService.GetAll().Where(a => a.productId == Id).First());
            ProductViewModel detailProduct = new ProductViewModel(prod.productId, prod.title, prod.price, prod.category, prod.commentsEnabled);
            var commments = productService.GetAllComments().Where(a => a.productId == Id);
            ViewBag.RelaventComments = commments;
            return View(detailProduct);
        }

    }
}