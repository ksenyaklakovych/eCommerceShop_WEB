namespace eCommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rate
    {
        public int rateID { get; set; }

        public int? productId { get; set; }

        [Column("rate")]
        public int rate1 { get; set; }

        public virtual Product Product { get; set; }
    }
}
