namespace eCommerce.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using eCommerce.BLL.DTO;
    using eCommerce.BLL.Interfaces;

    public interface IUserService
    {
        void CreateUser(UserDTO userDto);

        UserDTO GetById(int? id);

        UserDTO GetByUsernamePassword(string username, string password);

        IEnumerable<UserDTO> GetAll();

        void Dispose(int id);

        int FindMaxId();
    }
}
