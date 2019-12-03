namespace eCommerce.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;

    public class CommentDTO
    {
        public CommentDTO()
        {

        }

        public CommentDTO(int commentId, int productId, int userId, string message)
        {
            this.commentId = commentId;
            this.productId = productId;
            this.userId = userId;
            this.message = message;
        }

        public int commentId { get; set; }

        public int productId { get; set; }

        public int userId { get; set; }

        public string message { get; set; }

    }
}
