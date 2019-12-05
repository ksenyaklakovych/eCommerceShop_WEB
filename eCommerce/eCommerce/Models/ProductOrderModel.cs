namespace eCommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductOrderModel
    {
        public ProductOrderModel(int productId, int userId, string title, int price, string category, bool commentsEnabled, int quantity, bool payed, int totalPrice)
        {
            this.productId = productId;
            this.userId = userId;
            this.title = title;
            this.price = price;
            this.category = category;
            this.commentsEnabled = commentsEnabled;
            this.quantity = quantity;
            this.payed = payed;
            this.totalPrice= totalPrice;
        }

        public int productId { get; set; }
        public int userId { get; set; }

        public string title { get; set; }

        public int price { get; set; }

        public string category { get; set; }

        public bool commentsEnabled { get; set; }
        public int quantity { get; set; }
        public int totalPrice { get; set; }

        public bool payed { get; set; }
    }
}
