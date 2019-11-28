namespace eCommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Right
    {
        public int rightId { get; set; }

        public int? productId { get; set; }

        public int? userId { get; set; }

        public int? roleId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
