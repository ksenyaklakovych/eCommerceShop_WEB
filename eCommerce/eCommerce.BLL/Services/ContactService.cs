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

    public class ContactService: IContactService
    {
        public ContactService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IUnitOfWork Database { get; set; }

        public int FindMaxId()
        {
            int max = this.Database.Contacts.MaxId();
            return max;
        }

        public void CreateContact(ContactDTO o)
        {
            Contact d = new Contact
            {
                contactId=o.contactId,
                fullName = o.fullName,
                email=o.email,
                message=o.message
            };

            this.Database.Contacts.Create(d);
            this.Database.Save();
        }

        public ContactDTO GetById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("ID not set.", string.Empty);
            }

            var o = this.Database.Contacts.Get(id.Value);
            if (o == null)
            {
                throw new ValidationException("User with this ID was not found", string.Empty);
            }

            return new ContactDTO
            {
                contactId = o.contactId,
                fullName = o.fullName,
                email = o.email,
                message = o.message
            };
        }

        public IEnumerable<ContactDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Contact, ContactDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Contact>, List<ContactDTO>>(this.Database.Contacts.GetAll());
        }

        public void Dispose(int id)
        {
            var user = this.Database.Contacts.Get(id);
            if (user != null)
            {
                this.Database.Contacts.Delete(id);
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