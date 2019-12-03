namespace eCommerce.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;

    public class ProductDTO
    {
        public ProductDTO()
        {
        }

        public ProductDTO(int productId, string title, int price, string category, bool commentsEnabled)
        {
            this.productId = productId;
            this.title = title;
            this.price = price;
            this.category = category;
            this.commentsEnabled = commentsEnabled;
        }

        public int productId { get; set; }
        public string title { get; set; }

        public int price { get; set; }

        public string category { get; set; }

        public bool commentsEnabled { get; set; }

    }
}
