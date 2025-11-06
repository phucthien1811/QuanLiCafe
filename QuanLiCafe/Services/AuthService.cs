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

        /// <summary>
        /// ??ng nh?p - LINQ: FirstOrDefault
        /// </summary>
        public User? Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username);

            if (user == null)
                return null;

            // Verify password v?i BCrypt
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return user;
        }

        /// <summary>
        /// ??ng ký user m?i (ch? Admin)
        /// </summary>
        public void Register(string username, string password, string role)
        {
            // Ki?m tra username ?ã t?n t?i
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

        /// <summary>
        /// ??i m?t kh?u
        /// </summary>
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

        /// <summary>
        /// Ki?m tra quy?n Admin
        /// </summary>
        public bool IsAdmin(User user)
        {
            return user.Role == "Admin";
        }

        /// <summary>
        /// Ki?m tra quy?n Staff
        /// </summary>
        public bool IsStaff(User user)
        {
            return user.Role == "Staff";
        }

        /// <summary>
        /// Hash password v?i BCrypt (WorkFactor = 12)
        /// </summary>
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        /// <summary>
        /// Verify password v?i hash
        /// </summary>
        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
