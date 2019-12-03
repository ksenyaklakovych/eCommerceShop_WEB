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

    public class UserRepository : IRepository<User>
    {
        private commerceShopContext db;

        public UserRepository(commerceShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return this.db.Users;
        }

        public User Get(int id)
        {
            return this.db.Users.Find(id);
        }

        public void Create(User user)
        {
            this.db.Users.Add(user);
        }

        public void Update(User user)
        {
            this.db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return this.db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = this.db.Users.Find(id);
            if (user != null)
            {
                this.db.Users.Remove(user);
            }
        }

        public int MaxId()
        {
            int max = 0;
            try
            {
                max = this.db.Users.Max(a => a.userId);
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
