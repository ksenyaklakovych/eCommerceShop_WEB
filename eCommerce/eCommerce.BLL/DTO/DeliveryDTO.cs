namespace eCommerce.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;

    public partial class DeliveryDTO
    {
        public DeliveryDTO()
        {

        }

        public DeliveryDTO(int deliveryId, int totalPrice, string paymentType, string fullName, string address)
        {
            this.deliveryId = deliveryId;
            this.totalPrice = totalPrice;
            this.paymentType = paymentType;
            this.fullName = fullName;
            this.address = address;
        }

        public int deliveryId { get; set; }

        public int totalPrice { get; set; }

        public string paymentType { get; set; }

        public string fullName { get; set; }

        public string address { get; set; }
    }
}
