namespace eCommerce.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using eCommerce.BLL.DTO;
    using eCommerce.BLL.Interfaces;

    public interface IDeliveryService
    {
        void CreateDelivery(DeliveryDTO DTO);

        DeliveryDTO GetById(int? id);

        void Dispose(int id);

        int FindMaxId();

        IEnumerable<DeliveryDTO> GetAll();

        ////int Authenticate(string username, string password);
        //// void Update(User user, string password = null);
        ////void Create(string username, string password);
    }
}
