namespace eCommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CommentViewModel
    {
        public int commentId { get; set; }

        public int productId { get; set; }

        public int userId { get; set; }

        public string message { get; set; }
    }
}
