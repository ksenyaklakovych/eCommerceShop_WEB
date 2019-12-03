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

    public class UserService : IUserService
    {
        public UserService(IUnitOfWork uow)
        {
            this.Database = uow;
        }

        public IUnitOfWork Database { get; set; }

        public int FindMaxId()
        {
            int max = this.Database.Users.MaxId();
            return max;
        }

        public void CreateUser(UserDTO userDto)
        {
            User user = new User
            {
                userId = userDto.userId,
                username = userDto.username,
                password = userDto.password,
                isAdmin = userDto.isAdmin,
            };
            try
            {
                this.Database.Users.GetAll().Where(e => e.username == user.username).First();
                throw new ArgumentNullException();
            }
            catch (System.InvalidOperationException)
            {
                this.Database.Users.Create(user);
                this.Database.Save();
            }
        }


        public UserDTO GetById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("ID not set.", string.Empty);
            }

            var user = this.Database.Users.Get(id.Value);
            if (user == null)
            {
                throw new ValidationException("User with this ID was not found", string.Empty);
            }

            return new UserDTO
            {
                userId = user.userId,
                username = user.username,
                password = user.password,
                isAdmin = user.isAdmin
            };
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(this.Database.Users.GetAll());
        }

        public void Dispose(int id)
        {
            var user = this.Database.Users.Get(id);
            if (user != null)
            {
                this.Database.Users.Delete(id);
                this.Database.Save();
            }
        }

        public static string strKey = "U2A9/R*41FD412+4-123";

        public static string Encrypt(string strData)
        {
            string strValue = " ";
            if (!string.IsNullOrEmpty(strKey))
            {
                if (strKey.Length < 16)
                {
                    char c = "XXXXXXXXXXXXXXXX"[16];
                    strKey = strKey + strKey.Substring(0, 16 - strKey.Length);
                }

                if (strKey.Length > 16)
                {
                    strKey = strKey.Substring(0, 16);
                }

                // create encryption keys
                byte[] byteKey = Encoding.UTF8.GetBytes(strKey.Substring(0, 8));
                byte[] byteVector = Encoding.UTF8.GetBytes(strKey.Substring(strKey.Length - 8, 8));

                // convert data to byte array
                byte[] byteData = Encoding.UTF8.GetBytes(strData);

                // encrypt 
                DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
                MemoryStream objMemoryStream = new MemoryStream();
                CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateEncryptor(byteKey, byteVector), CryptoStreamMode.Write);
                objCryptoStream.Write(byteData, 0, byteData.Length);
                objCryptoStream.FlushFinalBlock();

                // convert to string and Base64 encode
                strValue = Convert.ToBase64String(objMemoryStream.ToArray());
            }
            else
            {
                strValue = strData;
            }

            return strValue;
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