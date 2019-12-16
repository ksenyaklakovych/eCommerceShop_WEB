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
        public ActionResult DeleteDelivery(int id)
        {
            deliveryService.Dispose(id);
            return RedirectToAction("DeliveryDetail");
        }
        public ActionResult DeliveryDetail()
        {
            IEnumerable<DeliveryDTO> deliveries = this.deliveryService.GetAll();
            return this.View(deliveries);
        }

    }
}