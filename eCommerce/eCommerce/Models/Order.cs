namespace eCommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int orderId { get; set; }

        public int? userId { get; set; }

        public int? productId { get; set; }

        public int quantity { get; set; }

        public bool payed { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
