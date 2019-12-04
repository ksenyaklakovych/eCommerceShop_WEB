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

    public class ProductRepository : IRepository<Product>
    {
        private commerceShopContext db;

        public ProductRepository(commerceShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return this.db.Products;
        }

        public Product Get(int id)
        {
            return this.db.Products.Find(id);
        }

        public Product GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Create(Product pr)
        {
            this.db.Products.Add(pr);
        }

        public void Update(Product pr)
        {
            this.db.Entry(pr).State = EntityState.Modified;
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return this.db.Products.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Product pr = this.db.Products.Find(id);
            if (pr != null)
            {
                this.db.Products.Remove(pr);
            }
        }

        public int MaxId()
        {
            int max = 0;
            try
            {
                max = this.db.Products.Max(a => a.productId);
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
