namespace eCommerce.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;

    public class RightDTO
    {
        public RightDTO()
        {
        }

        public RightDTO(int rightId, int productId, int userId, int roleId)
        {
            this.rightId = rightId;
            this.productId = productId;
            this.userId = userId;
            this.roleId = roleId;
        }

        public int rightId { get; set; }

        public int productId { get; set; }

        public int userId { get; set; }

        public int roleId { get; set; }
    }
}
