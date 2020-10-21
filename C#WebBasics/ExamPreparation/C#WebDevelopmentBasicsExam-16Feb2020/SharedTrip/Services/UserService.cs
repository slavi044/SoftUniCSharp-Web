using System.Text;
using System.Linq;
using SharedTrip.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Internal;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Password = ComputeHash(password),
                Email = email
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public bool IsEmailAvailable(string email)
        {
            return !this.db.Users.Any(x => x.Email == email);
        }

        public string GetUserId(string username, string password)
        {
            string hashPassword = ComputeHash(password);
            User user =  this.db.Users
                .FirstOrDefault(x => x.Username == username && x.Password == password);

            return user?.Id;
        }

        public bool IsUsernameAvailable(string username)
        {
            return !this.db.Users.Any(x => x.Username == username);
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }
}
