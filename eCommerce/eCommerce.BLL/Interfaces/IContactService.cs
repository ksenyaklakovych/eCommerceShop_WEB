namespace eCommerce.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using eCommerce.BLL.DTO;
    using eCommerce.BLL.Interfaces;

    public interface IContactService
    {
        void CreateContact(ContactDTO DTO);

        ContactDTO GetById(int? id);

        void Dispose(int id);

        int FindMaxId();

        IEnumerable<ContactDTO> GetAll();

        ////int Authenticate(string username, string password);
        //// void Update(User user, string password = null);
        ////void Create(string username, string password);
    }
}
