namespace eCommerce.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using eCommerce.BLL.DTO;
    using eCommerce.BLL.Interfaces;

    public interface IOrderService
    {
        void CreateOrder(OrderDTO orderDTO);

        OrderDTO GetById(int? id);

        //IEnumerable<OrderDTO> GetAll();

        void Dispose(int id);

        int FindMaxId();

        IEnumerable<OrderDTO> GetAllOrders();
        IEnumerable<ProductDTO> GetAllProducts();

        ////int Authenticate(string username, string password);
        //// void Update(User user, string password = null);
        ////void Create(string username, string password);
    }
}
