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

    public class DeliveryRepository : IRepository<Delivery>
    {
        private commerceShopContext db;

        public DeliveryRepository(commerceShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Delivery> GetAll()
        {
            return this.db.Deliveries;
        }

        public Delivery Get(int id)
        {
            return this.db.Deliveries.Find(id);
        }

        public Delivery GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Create(Delivery del)
        {
            this.db.Deliveries.Add(del);
        }

        public void Update(Delivery del)
        {
            this.db.Entry(del).State = EntityState.Modified;
        }

        public IEnumerable<Delivery> Find(Func<Delivery, bool> predicate)
        {
            return this.db.Deliveries.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Delivery c = this.db.Deliveries.Find(id);
            if (c != null)
            {
                this.db.Deliveries.Remove(c);
            }
        }

        public int MaxId()
        {
            int max = 0;
            try
            {
                max = 0;
            }
            catch (System.InvalidOperationException)
            {
                max = -1;
            }

            return max;
        }
    }
}
