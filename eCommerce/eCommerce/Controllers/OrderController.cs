using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Models;
using eCommerce.BLL.Interfaces;
using eCommerce.BLL.DTO;
using AutoMapper;
using eCommerce.BLL.Infrastructure;

namespace eCommerce.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService;

        public OrderController(IOrderService serv)
        {
            this.orderService = serv;
        }
        public ActionResult AddToCart(int productId)
        {
            int userId = int.Parse(Session["User_ID"].ToString());
            OrderDTO order = new OrderDTO(userId, productId, 1, false);
            orderService.CreateOrder(order);
            return this.RedirectToAction("ShoppingCart", "Order");
        }
        public ActionResult ShoppingCart()
        {
            IEnumerable<ProductDTO> products = this.orderService.GetAllProducts();
            IEnumerable<OrderDTO> orders = this.orderService.GetAllOrders();

            List<ProductOrderModel> productOrderModels = (from pr in products
                                                          from o in orders
                                                          where pr.productId == o.productId
                                                          select new ProductOrderModel(pr.productId, o.userId, pr.title, pr.price, pr.category, pr.commentsEnabled, o.quantity, o.payed, o.quantity * pr.price)).ToList();

            List<ProductOrderModel> uniqueOrders = new List<ProductOrderModel>();
            for (int i = 0; i < productOrderModels.Count; i++)
            {
                bool found = false;
                for (int k = 0; k < uniqueOrders.Count; k++)
                {
                    if (productOrderModels[i].title == uniqueOrders[k].title)
                    {
                        int new_quant = uniqueOrders[k].quantity + productOrderModels[i].quantity;
                        uniqueOrders[k] = new ProductOrderModel(uniqueOrders[k].productId, uniqueOrders[k].userId, uniqueOrders[k].title, uniqueOrders[k].price, uniqueOrders[k].category, uniqueOrders[k].commentsEnabled, new_quant, uniqueOrders[k].payed, uniqueOrders[k].price * new_quant);
                        found = true;
                    }
                }
                if (found==false)
                {
                    uniqueOrders.Add(productOrderModels[i]);
                }
            }
            IEnumerable<ProductOrderModel> viewModels = uniqueOrders;
            return View(viewModels);

        }
    }
}