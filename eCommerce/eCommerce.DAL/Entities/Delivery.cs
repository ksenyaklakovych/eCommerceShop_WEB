namespace eCommerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Delivery
    {
        public int deliveryId { get; set; }

        public int totalPrice { get; set; }

        [Required]
        public string paymentType { get; set; }

        [Required]
        public string fullName { get; set; }

        [Required]
        public string address { get; set; }
    }
}
