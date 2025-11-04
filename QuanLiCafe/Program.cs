using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuanLiCafe.Data;
using QuanLiCafe.Forms;
using System;
using System.IO;
using System.Windows.Forms;

namespace QuanLiCafe
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; } = null!;
        public static CafeContext DbContext { get; private set; } = null!;

        [STAThread]
        static void Main()
        {
            // Load configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            // Initialize DbContext
            var optionsBuilder = new DbContextOptionsBuilder<CafeContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            DbContext = new CafeContext(optionsBuilder.Options);

            // Run FormMain - Quản lý bàn
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
    }
}
