using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace eCommerce.Models
{
    public class ContactViewModel
    {
        public int contactId { get; set; }

        [DisplayName("Full name")]
        public string fullName { get; set; }

        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Your message")]
        public string message { get; set; }
    }
}