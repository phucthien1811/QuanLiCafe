using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuanLiCafe.Data;
using QuanLiCafe.Forms;
using QuanLiCafe.Models;
using QuanLiCafe.Helpers;
using System;
using System.IO;
using System.Windows.Forms;

namespace QuanLiCafe
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; } = null!;
        public static CafeContext DbContext { get; private set; } = null!;
        public static User? CurrentUser { get; set; } // ✅ Thêm current user

        [STAThread]
        static void Main()
        {
            // Load appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            // Initialize DbContext
            var optionsBuilder = new DbContextOptionsBuilder<CafeContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
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
