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

    public class ContactRepository : IRepository<Contact>
    {
        private commerceShopContext db;

        public ContactRepository(commerceShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Contact> GetAll()
        {
            return this.db.Contacts;
        }

        public Contact Get(int id)
        {
            return this.db.Contacts.Find(id);
        }

        public Contact GetbyPass(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Create(Contact comment)
        {
            this.db.Contacts.Add(comment);
        }

        public void Update(Contact comment)
        {
            this.db.Entry(comment).State = EntityState.Modified;
        }

        public IEnumerable<Contact> Find(Func<Contact, bool> predicate)
        {
            return this.db.Contacts.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Contact c = this.db.Contacts.Find(id);
            if (c != null)
            {
                this.db.Contacts.Remove(c);
            }
        }

        public int MaxId()
        {
            int max = 0;
            try
            {
                max = this.db.Contacts.Max(a => a.contactId);
            }
            catch (System.InvalidOperationException)
            {
                max = -1;
            }

            return max;
        }
    }
}
