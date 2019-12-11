namespace eCommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DeliveryModel
    {
        public DeliveryModel()
        {

        }

        public DeliveryModel(int deliveryId, int totalPrice, string paymentType, string fullName, string address)
        {
            this.deliveryId = deliveryId;
            this.totalPrice = totalPrice;
            this.paymentType = paymentType;
            this.fullName = fullName;
            this.address = address;
        }

        public int deliveryId { get; set; }

        [DisplayName("Total cost")]
        public int totalPrice { get; set; }

        [DisplayName("Payment type")]
        public string paymentType { get; set; }

        [DisplayName("Full name")]
        public string fullName { get; set; }

        [DisplayName("Shipping address")]
        public string address { get; set; }

    }
}
