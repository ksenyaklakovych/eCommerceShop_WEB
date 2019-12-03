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

    public class RightRepository : IRepository<Right>
    {
        private commerceShopContext db;

        public RightRepository(commerceShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Right> GetAll()
        {
            return this.db.Rights;
        }

        public Right Get(int id)
        {
            return this.db.Rights.Find(id);
        }

        public void Create(Right r)
        {
            this.db.Rights.Add(r);
        }

        public void Update(Right r)
        {
            this.db.Entry(r).State = EntityState.Modified;
        }

        public IEnumerable<Right> Find(Func<Right, bool> predicate)
        {
            return this.db.Rights.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Right r = this.db.Rights.Find(id);
            if (r != null)
            {
                this.db.Rights.Remove(r);
            }
        }

        public int MaxId()
        {
            int max = 0;
            try
            {
                max = this.db.Rights.Max(a => a.rightId);
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
