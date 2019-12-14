using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.Models
{
    public class ContactViewModel
    {
        public int contactId { get; set; }

        public string fullName { get; set; }

        public string email { get; set; }

        public string message { get; set; }
    }
}