namespace eCommerce.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using eCommerce.BLL.DTO;
    using eCommerce.BLL.Infrastructure;
    using eCommerce.BLL.Interfaces;
    using eCommerce.DAL.EF;
    using eCommerce.DAL.Entities;
    using eCommerce.DAL.Interfaces;

    public class CommentService: ICommentService
    {
        public CommentService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IUnitOfWork Database { get; set; }

        public int FindMaxId()
        {
            int max = this.Database.Comments.MaxId();
            return max;
        }

        public int FindMaxIdRate()
        {
            int max = this.Database.Rates.MaxId();
            return max;
        }

        public void CreateComment(CommentDTO o)
        {
            Comment d = new Comment
            {
                commentId=o.commentId,
                userId=o.userId,
                productId=o.productId,
                message=o.message
            };

            this.Database.Comments.Create(d);
            this.Database.Save();
        }

        public void CreateRate(RateDTO o)
        {
            Rate d = new Rate
            {
               rateID = o.rateID,
            productId = o.productId,
            rate1 = o.rate1,
            };

            this.Database.Rates.Create(d);
            this.Database.Save();
        }

        public CommentDTO GetById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("ID not set.", string.Empty);
            }

            var o = this.Database.Comments.Get(id.Value);
            if (o == null)
            {
                throw new ValidationException("User with this ID was not found", string.Empty);
            }

            return new CommentDTO
            {
                commentId = o.commentId,
                userId = (int)o.userId,
                productId = (int)o.productId,
                message = o.message
            };
        }

        public IEnumerable<CommentDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(this.Database.Comments.GetAll());
        }

        public void Dispose(int id)
        {
            var user = this.Database.Comments.Get(id);
            if (user != null)
            {
                this.Database.Comments.Delete(id);
                this.Database.Save();
            }
        }

        //public UserDTO GetByUsernamePassword(string username, string password)
        //    {
        //        try
        //        {
        //            var user = this.Database.Users.GetbyPass(username, Encrypt(password));
        //            return new UserDTO
        //            {
        //                userId = user.userId,
        //                username = user.username,
        //                password = user.password,
        //                isAdmin = user.isAdmin
        //            };
        //        }
        //        catch (System.NullReferenceException)
        //        {
        //            return null;
        //        }
        //    }
        //}
    }
}