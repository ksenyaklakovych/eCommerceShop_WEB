namespace eCommerce.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using eCommerce.DAL.Entities;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class commerceShopContext : DbContext
    {
        public commerceShopContext()
            : base("name=shopDB")
        {
        }
        private string connectionString;

        public commerceShopContext(string conString)
        {
            this.connectionString = conString;
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Right> Rights { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Deliver> Deliveries { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.message)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}