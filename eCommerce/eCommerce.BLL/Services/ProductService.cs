﻿namespace eCommerce.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using eCommerce.BLL.DTO;
    using eCommerce.BLL.Infrastructure;
    using eCommerce.BLL.Interfaces;
    using eCommerce.DAL.EF;
    using eCommerce.DAL.Entities;
    using eCommerce.DAL.Interfaces;

    public class ProductService : IProductService
    {
        public ProductService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IUnitOfWork Database { get; set; }

        public int FindMaxId()
        {
            int max = this.Database.Products.MaxId();
            return max;
        }

        public int FindMaxIdRate()
        {
            int max = this.Database.Rates.MaxId();
            return max;
        }

        public void CreateProduct(ProductDTO o)
        {
            Product product = new Product
            {
                productId=o.productId,
                title=o.title,
                price=o.price,
                category=o.category,
                commentsEnabled=o.commentsEnabled
            };

            this.Database.Products.Create(product);
            this.Database.Save();
        }

        public void CreateRate(RateDTO r)
        {
            Rate rate = new Rate()
            {
                rateID = r.rateID,
                productId = r.productId,
                rate1 = r.rate
            };
            this.Database.Rates.Create(rate);
            this.Database.Save();
        }
        public void Update(ProductDTO o)
        {
            Product product = new Product
            {
                productId = o.productId,
                title = o.title,
                price = o.price,
                category = o.category,
                commentsEnabled = o.commentsEnabled
            };

            this.Database.Products.Update(product);
            this.Database.Save();

        }

        public ProductDTO GetById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("ID not set.", string.Empty);
            }

            var o = this.Database.Products.Get(id.Value);
            if (o == null)
            {
                throw new ValidationException("User with this ID was not found", string.Empty);
            }

            return new ProductDTO
            {
                productId = o.productId,
                title = o.title,
                price = o.price,
                category = o.category,
                commentsEnabled = o.commentsEnabled
            };
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(this.Database.Products.GetAll());
        }

        public IEnumerable<CommentDTO> GetAllComments()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(this.Database.Comments.GetAll());
        }
        public IEnumerable<RateDTO> GetAllRates()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Rate, RateDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Rate>, List<RateDTO>>(this.Database.Rates.GetAll());
        }
        public IEnumerable<OrderDTO> GetAllOrders()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(this.Database.Orders.GetAll());
        }
        public void Dispose(int id)
        {
            var user = this.Database.Products.Get(id);
            if (user != null)
            {
                this.Database.Products.Delete(id);
                this.Database.Save();
            }
        }
        public void DisposeOrder(int id)
        {
            var user = this.Database.Orders.Get(id);
            if (user != null)
            {
                this.Database.Orders.Delete(id);
                this.Database.Save();
            }
        }
        public void DisposeComment(int id)
        {
            var user = this.Database.Comments.Get(id);
            if (user != null)
            {
                this.Database.Comments.Delete(id);
                this.Database.Save();
            }
        }

        public static string strKey = "U2A9/R*41FD412+4-123";

        public static string Encrypt(string strData)
        {
            string strValue = " ";
            if (!string.IsNullOrEmpty(strKey))
            {
                if (strKey.Length < 16)
                {
                    char c = "XXXXXXXXXXXXXXXX"[16];
                    strKey = strKey + strKey.Substring(0, 16 - strKey.Length);
                }

                if (strKey.Length > 16)
                {
                    strKey = strKey.Substring(0, 16);
                }

                // create encryption keys
                byte[] byteKey = Encoding.UTF8.GetBytes(strKey.Substring(0, 8));
                byte[] byteVector = Encoding.UTF8.GetBytes(strKey.Substring(strKey.Length - 8, 8));

                // convert data to byte array
                byte[] byteData = Encoding.UTF8.GetBytes(strData);

                // encrypt
                DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
                MemoryStream objMemoryStream = new MemoryStream();
                CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateEncryptor(byteKey, byteVector), CryptoStreamMode.Write);
                objCryptoStream.Write(byteData, 0, byteData.Length);
                objCryptoStream.FlushFinalBlock();

                // convert to string and Base64 encode
                strValue = Convert.ToBase64String(objMemoryStream.ToArray());
            }
            else
            {
                strValue = strData;
            }

            return strValue;
        }





        //public UserDTO GetByUsernamePassword(string username, string password)
        //    {
        //        try
        //        {
        //            var user = this.Database.Users.GetbyPass(username, Encrypt(password));
        //            return new UserDTO
        //            {
        //                userId = user.userId,
        //                username = user.username,
        //                password = user.password,
        //                isAdmin = user.isAdmin
        //            };
        //        }
        //        catch (System.NullReferenceException)
        //        {
        //            return null;
        //        }
        //    }
        //}
    }
}
