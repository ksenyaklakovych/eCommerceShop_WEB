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

    public class CommentRepository : IRepository<Comment>
    {
        private commerceShopContext db;

        public CommentRepository(commerceShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return this.db.Comments;
        }

        public Comment Get(int id)
        {
            return this.db.Comments.Find(id);
        }

        public void Create(Comment comment)
        {
            this.db.Comments.Add(comment);
        }

        public void Update(Comment comment)
        {
            this.db.Entry(comment).State = EntityState.Modified;
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            return this.db.Comments.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Comment c = this.db.Comments.Find(id);
            if (c != null)
            {
                this.db.Comments.Remove(c);
            }
        }

        public int MaxId()
        {
            int max = 0;
            try
            {
                max = this.db.Comments.Max(a => a.commentId);
            }
            catch (System.InvalidOperationException)
            {
                max = -1;
            }

            return max;
        }
    }
}
