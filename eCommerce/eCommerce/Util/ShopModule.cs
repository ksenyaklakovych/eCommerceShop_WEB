namespace eCommerce.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Ninject.Modules;
    using eCommerce.BLL.Interfaces;
    using eCommerce.BLL.Services;

    public class ShopModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserService>().To<UserService>();
            this.Bind<IProductService>().To<ProductService>();
            this.Bind<IOrderService>().To<OrderService>();
            this.Bind<ICommentService>().To<CommentService>();
            this.Bind<IContactService>().To<ContactService>();

        }
    }
}