namespace eCommerce.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;

    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(int userId, string username, string password, string isAdmin)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.isAdmin = isAdmin;
        }

        public int userId { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string isAdmin { get; set; }

    }
}
