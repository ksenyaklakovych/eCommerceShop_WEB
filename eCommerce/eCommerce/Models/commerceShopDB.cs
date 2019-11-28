namespace eCommerce.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class commerceShopDB : DbContext
    {
        public commerceShopDB()
            : base("name=shopDB")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Right> Rights { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
