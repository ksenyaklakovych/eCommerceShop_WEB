namespace eCommerce.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;

    public class ContactDTO
    {
        public ContactDTO() { }

        public ContactDTO( int contactId, string fullName, string email, string message) 
        {
            this.contactId = contactId;
            this.fullName = fullName;
            this.email = email;
            this.message = message;
        }

        public int contactId { get; set; }

        public string fullName { get; set; }

        public string email { get; set; }

        public string message { get; set; }

    }
}
