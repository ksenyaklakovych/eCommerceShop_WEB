namespace eCommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductViewModel
    {
        public int productId { get; set; }
        public string title { get; set; }

        public int price { get; set; }

        public string category { get; set; }

        public bool commentsEnabled { get; set; }

        public ProductViewModel(int productId, string title, int price, string category, bool commentsEnabled)
        {
            this.productId = productId;
            this.title = title;
            this.price = price;
            this.category = category;
            this.commentsEnabled = commentsEnabled;
        }
    }
}
