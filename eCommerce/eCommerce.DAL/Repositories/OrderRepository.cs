namespace eCommerce.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using eCommerce.DAL.EF;
    using eCommerce.DAL.Entities;
    using eCommerce.DAL.Interfaces;

    public class OrderRepository : IRepository<Order>
    {
        private commerceShopContext db;

        public OrderRepository(commerceShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return this.db.Orders;
        }

        public Order Get(int id)
        {
            return this.db.Orders.Find(id);
        }

        public Order GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Create(Order o)
        {
            this.db.Orders.Add(o);
        }

        public void Update(Order o)
        {
            this.db.Entry(o).State = EntityState.Modified;
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return this.db.Orders.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Order o = this.db.Orders.Find(id);
            if (o != null)
            {
                this.db.Orders.Remove(o);
            }
        }

        public int MaxId()
        {
            int max = 0;
            try
            {
                max = this.db.Orders.Max(a => a.orderId);
            }
            catch (System.InvalidOperationException)
            {
                max = -1;
            }

            return max;
        }

        //public User GetbyPass(string username, string password)
        //{
        //    return this.db.Users.Where(a => a.username == username && a.password == password).ToList().FirstOrDefault();
        //}
    }
}
