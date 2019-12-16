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
    public class DeliveryController : Controller
    {
        private IDeliveryService deliveryService;

        public DeliveryController(IDeliveryService dels)
        {
            this.deliveryService = dels;
        }
        //[HttpGet]
        public ActionResult DeleteDelivery(int id)
        {
            deliveryService.Dispose(id);
            return RedirectToAction("DeliveryDetail");
        }
        public ActionResult DeliveryDetail()
        {
            //var prod = (deliveryService.GetAll().Where(a => a.deliveryId == Id).First());
            //ViewModel detailProduct = new ProductViewModel(prod.productId, prod.title, prod.price, prod.category, prod.commentsEnabled);
            //var commments = deliveryService.().Where(a => a.productId == Id);
            //ViewBag.RelaventComments = commments;
            //return View(detailProduct);
            IEnumerable<DeliveryDTO> deliveries = this.deliveryService.GetAll();
            return this.View(deliveries);
        }

    }
}