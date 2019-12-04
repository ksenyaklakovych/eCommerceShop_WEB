namespace eCommerce.DAL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using eCommerce.DAL.Entities;

    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Role> Roles { get; }

        IRepository<Right> Rights { get; }

        IRepository<Rate> Rates { get; }

        IRepository<Product> Products { get; }

        IRepository<Order> Orders { get; }
        IRepository<Contact> Contacts { get; }


        void Save();
    }
}
