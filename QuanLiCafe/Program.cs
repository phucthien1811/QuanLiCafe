using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;
using QuanLiCafe.Forms;
using QuanLiCafe.Models;
using QuanLiCafe.Helpers;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace QuanLiCafe
{
    internal static class Program
    {
        public static CafeContext DbContext { get; private set; } = null!;
        public static User? CurrentUser { get; set; }

        [STAThread]
        static void Main()
        {
            // ✅ Đọc connection string từ App.config
            string? connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Không tìm thấy connection string trong App.config!", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Initialize DbContext
            var optionsBuilder = new DbContextOptionsBuilder<CafeContext>();
            optionsBuilder.UseSqlServer(connectionString);
            DbContext = new CafeContext(optionsBuilder.Options);

            // ✅ Seed demo data (50 orders + BCrypt passwords)
            try
            {
                DatabaseSeeder.SeedDemoData(DbContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Seed warning: {ex.Message}");
            }

            // ✅ Show Login Form
            ApplicationConfiguration.Initialize();
            
            using (var loginForm = new FormLogin())
            {
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    return; // User cancelled login
                }

                CurrentUser = loginForm.LoggedInUser;
            }

            // ✅ Show Main Form with logged in user
            Application.Run(new FormMain());
        }
    }
}
