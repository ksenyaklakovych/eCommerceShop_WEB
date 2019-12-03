﻿namespace eCommerce.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    //using eCommerce;
    using eCommerce.DAL.EF;
    using eCommerce.DAL.Entities;
    using eCommerce.DAL.Interfaces;

    public class EFUnitOfWork : IUnitOfWork
    {
        private commerceShopContext db;
        private UserRepository userRepository;
        private CommentRepository commentRepository;
        private RateRepository rateRepository;
        private ProductRepository productRepository;
        private OrderRepository orderRepository;
        private RoleRepository roleRepository;
        private RightRepository rightRepository;
        private bool disposed = false;

        public EFUnitOfWork(string connectionString)
        {
            this.db = new commerceShopContext(connectionString);
        }

        public EFUnitOfWork(commerceShopContext db)
        {
            this.db = db;
            this.userRepository = new UserRepository(db);
            this.commentRepository = new CommentRepository(db);
            this.rateRepository = new RateRepository(db);
            this.productRepository = new ProductRepository(db);
            this.orderRepository = new OrderRepository(db);
            this.roleRepository = new RoleRepository(db);
            this.rightRepository = new RightRepository(db);
        }

        public IRepository<User> Users
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(this.db);
                }

                return this.userRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (this.commentRepository == null)
                {
                    this.commentRepository = new CommentRepository(this.db);
                }

                return this.commentRepository;
            }
        }

        public IRepository<Rate> Rates
        {
            get
            {
                if (this.rateRepository == null)
                {
                    this.rateRepository = new RateRepository(this.db);
                }

                return this.rateRepository;
            }
        }

        public IRepository<Order> Dates_ranges
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new OrderRepository(this.db);
                }

                return this.orderRepository;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new ProductRepository(this.db);
                }

                return this.productRepository;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new RoleRepository(this.db);
                }

                return this.roleRepository;
            }
        }

        public IRepository<Right> Rights
        {
            get
            {
                if (this.rightRepository == null)
                {
                    this.rightRepository = new RightRepository(this.db);
                }

                return this.rightRepository;
            }
        }

        public void Save()
        {
            this.db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.db.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}