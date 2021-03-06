﻿namespace eCommerce.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using eCommerce.BLL.DTO;
    using eCommerce.BLL.Interfaces;

    public interface IProductService
    {
        void CreateProduct(ProductDTO ProductDTO);

        void CreateRate(RateDTO RateDTO);

        void Update(ProductDTO pr);
        ProductDTO GetById(int? id);

        //IEnumerable<OrderDTO> GetAll();

        void Dispose(int id);
        void DisposeOrder(int id);
        void DisposeComment(int id);


        int FindMaxId();
        int FindMaxIdRate();


        IEnumerable<ProductDTO> GetAll();
        IEnumerable<CommentDTO> GetAllComments();
        IEnumerable<RateDTO> GetAllRates();
        IEnumerable<OrderDTO> GetAllOrders();
        ////int Authenticate(string username, string password);
        //// void Update(User user, string password = null);
        ////void Create(string username, string password);
    }
}
