namespace eCommerce.BLL.Services
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

    public class DeliveryService : IDeliveryService
    {
        public DeliveryService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IUnitOfWork Database { get; set; }

        public int FindMaxId()
        {
            int max = this.Database.Deliveries.MaxId();
            return max;
        }

        public void CreateDelivery(DeliveryDTO o)
        {
            Delivery d = new Delivery
            {
                deliveryId = o.deliveryId,
                totalPrice = o.totalPrice,
                paymentType = o.paymentType,
                fullName = o.fullName,
                address = o.address,

            };

            this.Database.Deliveries.Create(d);
            this.Database.Save();
        }


        public DeliveryDTO GetById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("ID not set.", string.Empty);
            }

            var o = this.Database.Deliveries.Get(id.Value);
            if (o == null)
            {
                throw new ValidationException("User with this ID was not found", string.Empty);
            }

            return new DeliveryDTO
            {
                deliveryId = o.deliveryId,
                totalPrice = o.totalPrice,
                paymentType = o.paymentType,
                fullName = o.fullName,
                address = o.address,
            };
        }

        public IEnumerable<DeliveryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Delivery, DeliveryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Delivery>, List<DeliveryDTO>>(this.Database.Deliveries.GetAll());
        }

        public void Dispose(int id)
        {
            var user = this.Database.Deliveries.Get(id);
            if (user != null)
            {
                this.Database.Deliveries.Delete(id);
                this.Database.Save();
            }
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