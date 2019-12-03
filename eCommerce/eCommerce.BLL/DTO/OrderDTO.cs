namespace eCommerce.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;

    public class OrderDTO
    {
        public OrderDTO()
        {

        }
        public OrderDTO(int orderId, int userId, int productId, int quantity, bool payed)
        {
            this.orderId = orderId;
            this.userId = userId;
            this.productId = productId;
            this.quantity = quantity;
            this.payed = payed;
        }

        public int orderId { get; set; }

        public int userId { get; set; }

        public int productId { get; set; }

        public int quantity { get; set; }

        public bool payed { get; set; }

    }
}
