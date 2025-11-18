using BCrypt.Net;
using QuanLiCafe.Data;
using QuanLiCafe.Models;

namespace QuanLiCafe.Services
{
    public class AuthService : IAuthService
    {
        private readonly CafeContext _context;

        public AuthService(CafeContext context)
        {
            _context = context;
        }

       
        public User? Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username);

            if (user == null)
                return null;

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return user;
        }

       
        public void Register(string username, string password, string role)
        {
     
            var existing = _context.Users
                .FirstOrDefault(u => u.Username == username);

            if (existing != null)
                throw new InvalidOperationException($"Username '{username}' ?ã t?n t?i!");

            // Validate role
            if (role != "Admin" && role != "Staff")
                throw new ArgumentException("Role ph?i là 'Admin' ho?c 'Staff'");

            var user = new User
            {
                Username = username,
                PasswordHash = HashPassword(password),
                Role = role
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
                throw new InvalidOperationException("User không t?n t?i!");

            // Verify old password
            if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.PasswordHash))
                throw new InvalidOperationException("M?t kh?u c? không ?úng!");

            user.PasswordHash = HashPassword(newPassword);
            _context.SaveChanges();
        }

        public bool IsAdmin(User user)
        {
            return user.Role == "Admin";
        }

      
        public bool IsStaff(User user)
        {
            return user.Role == "Staff";
        }

        
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
