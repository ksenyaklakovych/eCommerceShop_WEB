namespace eCommerce.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;

    public class RoleDTO
    {
        public RoleDTO()
        {
        }

        public RoleDTO(int roleId, string title)
        {
            this.roleId = roleId;
            this.title = title;
        }

        public int roleId { get; set; }
        public string title { get; set; }
    }
}
