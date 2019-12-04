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

    public class RoleRepository : IRepository<Role>
    {
        private commerceShopContext db;

        public RoleRepository(commerceShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return this.db.Roles;
        }

        public Role Get(int id)
        {
            return this.db.Roles.Find(id);
        }

        public Role GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Create(Role role)
        {
            this.db.Roles.Add(role);
        }

        public void Update(Role role)
        {
            this.db.Entry(role).State = EntityState.Modified;
        }

        public IEnumerable<Role> Find(Func<Role, bool> predicate)
        {
            return this.db.Roles.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Role role = this.db.Roles.Find(id);
            if (role != null)
            {
                this.db.Roles.Remove(role);
            }
        }

        public int MaxId()
        {
            int max = 0;
            try
            {
                max = this.db.Roles.Max(a => a.roleId);
            }
            catch (System.InvalidOperationException)
            {
                max = -1;
            }

            return max;
        }

    }
}
