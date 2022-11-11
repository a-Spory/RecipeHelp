using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RecipeHelp.Models
{
    public class EfUserRepo : IUserRepo
    {

        //FIELDS & PROPERTIES

        private AppDbContext _context;
        private ISession _session;

        //CONSTRUCTORS

        public EfUserRepo(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _session = httpContextAccessor.HttpContext.Session;
        }

        public EfUserRepo()
        {
        }

        //METHODS

        //CREATE
        public User Create(User u)
        {
            String encryptedPass = EncryptPassword(u.Password);
            u.Password = encryptedPass;

            User existingUser = GetUserByEmail(u.Email);
            if (existingUser != null) return null;

            try
            {
                _context.Users.Add(u);
                _context.SaveChanges();
                return u;
            }
            catch (Exception e)
            {
            }

            return null;

        }

        //READ
        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public IQueryable<User> GetAllUsers()
        {
            return _context.Users.OrderBy(u => u.Email);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users
                .FirstOrDefault(u => u.Email == email);
        }

        public bool Login(User user)
        {
            String encPass = EncryptPassword(user.Password);

            User existingUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == encPass);

            if (existingUser == null || existingUser.Password != encPass)
            {
                return false;
            }
            else
            {
                _session.SetInt32("userid", existingUser.Id);
                _session.SetString("username", user.UserName);
                return true;
            }
        }

        public void Logout()
        {
            _session.Remove("userid");
            _session.Remove("username");
        }

        public bool IsUserLoggedIn()
        {
            int? userId = _session.GetInt32("userid");
            if (userId == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetLoggedInUserId()
        {
            int? userId = _session.GetInt32("userid");
            if (userId == null)
            {
                return -1;
            }
            else
            {
                return userId.Value;
            }
        }

        public string GetLoggedInUserName()
        {
            return _session.GetString("username");
        }

        


        //UPDATE
        public User Update(User u)
        {
            User userToUpdate = GetUserById(u.Id);
            if (userToUpdate != null)
            {
                userToUpdate.Name = u.Name;
                userToUpdate.Email = u.Email;
                userToUpdate.Password = u.Password;
                _context.SaveChanges();
            }

            return userToUpdate;
        }

        public bool ChangePassword(string oldPass, string newPass)
        {
            if (!IsUserLoggedIn()) return false;

            User userToUpdate = GetUserById(GetLoggedInUserId());
            if (userToUpdate != null && userToUpdate.Password == oldPass)
            {
                userToUpdate.Password = newPass;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        //DELETE
        public bool DeleteUser(int id)
        {
            User userToDelete = GetUserById(id);
            if (userToDelete == null) return false;

            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteUser(User user)
        {
            return DeleteUser(user.Id);
        }

        //PRIVATE METHODS
        private String EncryptPassword(String pass)
        {
            SHA256 hashAlg = SHA256.Create();

            byte[] passArray = Encoding.ASCII.GetBytes(pass);
            byte[] encyptPassArray = hashAlg.ComputeHash(passArray);

            String result = BitConverter.ToString(encyptPassArray);
            result = result.Replace("-", "");

            return result;
        }

        private String GenerateRandPass(int length = 15)
        {
            Random r = new Random();
            String result = "";

            for (int i = 0; i <= length; i++)
            {
                result = result + (char)r.Next(33, 126);
            }

            return result;
        }
    }
}
