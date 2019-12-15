namespace eCommerce.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;
    using System.ComponentModel;

    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(int userId, string username, string password, bool isAdmin)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.isAdmin = isAdmin;
        }

        public int userId { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        [DisplayName("Is admin ")]
        public bool isAdmin { get; set; }

    }
}
