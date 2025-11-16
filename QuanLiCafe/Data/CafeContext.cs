using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Models;
using System.Security.Cryptography;
using System.Text;

namespace QuanLiCafe.Data
{
    public class CafeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ImportHistory> ImportHistories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EmployeeInformation> EmployeeInformations { get; set; } // ✅ THÊM MỚI

        public CafeContext(DbContextOptions<CafeContext> options) : base(options) { }

        // ✅ Cấu hình kết nối SQL Server Express
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CafeDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User Configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(256);
                entity.Property(e => e.Role).IsRequired().HasMaxLength(20);
            });

            // ✅ EmployeeInformation Configuration
            modelBuilder.Entity<EmployeeInformation>(entity =>
            {
                entity.ToTable("EmployeeInformations");
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.Property(e => e.IdentityCard).HasMaxLength(50);
                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.HasOne(e => e.User)
                    .WithOne()
                    .HasForeignKey<EmployeeInformation>(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Table Configuration
            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("Tables");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(20).HasDefaultValue("Free");
            });

            // Category Configuration
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            // Product Configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.ImageUrl).HasMaxLength(500);

                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Order Configuration
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.Discount).HasColumnType("decimal(5,2)").HasDefaultValue(0);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");

                entity.HasOne(e => e.Table)
                    .WithMany(t => t.Orders)
                    .HasForeignKey(e => e.TableId)
                    .OnDelete(DeleteBehavior.Restrict);

                // ✅ ĐỔI SANG SetNull - Khi xóa User, StaffId sẽ = NULL
                entity.HasOne(e => e.Staff)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(e => e.StaffId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired(false); // Cho phép NULL
            });

            // OrderDetail Configuration
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetails");
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.Note).HasMaxLength(500);

                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Inventory Configuration
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventories");
                entity.Property(e => e.MaterialName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Unit).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Quantity).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.ReorderLevel).IsRequired().HasColumnType("decimal(18,2)");
            });

            // ImportHistory Configuration
            modelBuilder.Entity<ImportHistory>(entity =>
            {
                entity.ToTable("ImportHistories");
                entity.Property(e => e.Quantity).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.Cost).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.ImportedAt).IsRequired();

                entity.HasOne(e => e.Material)
                    .WithMany(i => i.ImportHistories)
                    .HasForeignKey(e => e.MaterialId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Customer Configuration
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
                entity.HasIndex(e => e.PhoneNumber); // Index cho tìm kiếm nhanh
            });

            // Seed dữ liệu ban đầu
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Hàm mã hóa mật khẩu
            string HashPassword(string password)
            {
                using var sha256 = SHA256.Create();
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", PasswordHash = HashPassword("admin123"), Role = "Admin" },
                new User { Id = 2, Username = "staff01", PasswordHash = HashPassword("staff123"), Role = "Staff" }
            );

            // Seed Tables
            modelBuilder.Entity<Table>().HasData(
                new Table { Id = 1, Name = "Bàn 1", Status = "Free" },
                new Table { Id = 2, Name = "Bàn 2", Status = "Free" },
                new Table { Id = 3, Name = "Bàn 3", Status = "Free" },
                new Table { Id = 4, Name = "Bàn 4", Status = "Free" },
                new Table { Id = 5, Name = "Bàn 5", Status = "Free" }
            );

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Cà phê" },
                new Category { Id = 2, Name = "Trà sữa" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Cà phê đen", Price = 25000, CategoryId = 1, ImageUrl = "/images/ca-phe-den.jpg" },
                new Product { Id = 2, Name = "Cà phê sữa", Price = 30000, CategoryId = 1, ImageUrl = "/images/ca-phe-sua.jpg" },
                new Product { Id = 3, Name = "Bạc xỉu", Price = 28000, CategoryId = 1, ImageUrl = "/images/bac-xiu.jpg" },
                new Product { Id = 4, Name = "Trà sữa truyền thống", Price = 35000, CategoryId = 2, ImageUrl = "/images/tra-sua-truyen-thong.jpg" },
                new Product { Id = 5, Name = "Trà sữa matcha", Price = 40000, CategoryId = 2, ImageUrl = "/images/tra-sua-matcha.jpg" }
            );

            // Seed Inventories
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Id = 1, MaterialName = "Cà phê hạt", Unit = "kg", Quantity = 50, ReorderLevel = 10 },
                new Inventory { Id = 2, MaterialName = "Sữa tươi", Unit = "lít", Quantity = 30, ReorderLevel = 15 },
                new Inventory { Id = 3, MaterialName = "Đường", Unit = "kg", Quantity = 8, ReorderLevel = 20 },
                new Inventory { Id = 4, MaterialName = "Trà xanh", Unit = "kg", Quantity = 5, ReorderLevel = 10 },
                new Inventory { Id = 5, MaterialName = "Matcha", Unit = "kg", Quantity = 3, ReorderLevel = 5 }
            );
        }
    }
}
