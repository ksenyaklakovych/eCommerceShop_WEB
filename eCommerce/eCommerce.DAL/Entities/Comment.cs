namespace eCommerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int commentId { get; set; }

        public int? productId { get; set; }

        public int? userId { get; set; }

        [Required]
        [StringLength(50)]
        public string message { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
