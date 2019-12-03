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

        public RateDTO(int rateID, int productId, int rate1)
        {
            this.rateID = rateID;
            this.productId = productId;
            this.rate1 = rate1;
        }

        public int rateID { get; set; }

        public int productId { get; set; }

        public int rate1 { get; set; }

    }
}
