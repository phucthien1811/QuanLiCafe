using QuanLiCafe.Models;

namespace QuanLiCafe.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// ??ng nh?p v?i username và password
        /// </summary>
        User? Login(string username, string password);

        /// <summary>
        /// ??ng ký user m?i (ch? Admin)
        /// </summary>
        void Register(string username, string password, string role);

        /// <summary>
        /// ??i m?t kh?u
        /// </summary>
        void ChangePassword(int userId, string oldPassword, string newPassword);

        /// <summary>
        /// Ki?m tra quy?n Admin
        /// </summary>
        bool IsAdmin(User user);

        /// <summary>
        /// Ki?m tra quy?n Staff
        /// </summary>
        bool IsStaff(User user);

        /// <summary>
        /// Hash password v?i BCrypt
        /// </summary>
        string HashPassword(string password);

        /// <summary>
        /// Verify password v?i hash
        /// </summary>
        bool VerifyPassword(string password, string hash);
    }
}
