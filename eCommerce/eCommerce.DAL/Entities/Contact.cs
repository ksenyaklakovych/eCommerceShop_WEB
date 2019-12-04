namespace eCommerce.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contact
    {
        public int contactId { get; set; }

        public string fullName { get; set; }

        public string email { get; set; }

        public string message { get; set; }

    }
}
