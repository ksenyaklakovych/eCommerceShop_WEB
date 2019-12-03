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

    public class RateRepository : IRepository<Rate>
    {
        private commerceShopContext db;

        public RateRepository(commerceShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Rate> GetAll()
        {
            return this.db.Rates;
        }

        public Rate Get(int id)
        {
            return this.db.Rates.Find(id);
        }

        public void Create(Rate r)
        {
            this.db.Rates.Add(r);
        }

        public void Update(Rate r)
        {
            this.db.Entry(r).State = EntityState.Modified;
        }

        public IEnumerable<Rate> Find(Func<Rate, bool> predicate)
        {
            return this.db.Rates.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Rate r = this.db.Rates.Find(id);
            if (r != null)
            {
                this.db.Rates.Remove(r);
            }
        }

        public int MaxId()
        {
            int max = 0;
            try
            {
                max = this.db.Rates.Max(a => a.rateID);
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
