namespace eCommerce.BLL.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Ninject.Modules;
    using eCommerce.DAL.Interfaces;
    using eCommerce.DAL.Repositories;

    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            this.connectionString = connection;
        }

        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(this.connectionString);
        }
    }
}
