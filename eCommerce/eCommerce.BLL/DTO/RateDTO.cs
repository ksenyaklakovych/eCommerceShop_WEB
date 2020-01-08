namespace eCommerce.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;

    public class RateDTO
    {
        public RateDTO()
        {
        }

        public RateDTO(int rateID, int productId, int rate)
        {
            this.rateID = rateID;
            this.productId = productId;
            this.rate = rate;
        }

        public int rateID { get; set; }

        public int productId { get; set; }

        public int rate { get; set; }

    }
}
