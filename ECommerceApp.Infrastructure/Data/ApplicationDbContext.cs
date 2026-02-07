using ECommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ECommerceApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Download> Downloads { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);

                entity.HasMany(u => u.Orders)
                      .WithOne(o => o.User)
                      .HasForeignKey(o => o.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.HasIndex(e => e.Name);

                entity.HasOne(c => c.ParentCategory)
                      .WithMany(c => c.SubCategories)
                      .HasForeignKey(c => c.ParentCategoryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(c => c.Products)
                      .WithOne(p => p.Category)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.ShortDescription).HasMaxLength(500);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.FileUrl).HasMaxLength(500);
                entity.Property(e => e.ThumbnailUrl).HasMaxLength(500);
                entity.HasIndex(e => e.Name);
                entity.HasIndex(e => e.CategoryId);

                entity.HasMany(p => p.OrderItems)
                      .WithOne(oi => oi.Product)
                      .HasForeignKey(oi => oi.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OrderNumber).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.OrderNumber).IsUnique();
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Status).IsRequired().HasMaxLength(20);
                entity.Property(e => e.PaymentIntentId).HasMaxLength(100);
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.Status);

                entity.HasMany(o => o.OrderItems)
                      .WithOne(oi => oi.Order)
                      .HasForeignKey(oi => oi.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Subtotal).HasColumnType("decimal(18,2)");
                entity.HasIndex(e => e.OrderId);
                entity.HasIndex(e => e.ProductId);
            });

            modelBuilder.Entity<Download>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IpAddress).IsRequired().HasMaxLength(45);
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.ProductId);
                entity.HasIndex(e => e.OrderId);

                entity.HasOne(d => d.User)
                      .WithMany()
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Product)
                      .WithMany()
                      .HasForeignKey(d => d.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Order)
                      .WithMany()
                      .HasForeignKey(d => d.OrderId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties()
                    .Where(p => p.Name == "CreatedAt");

                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(property.Name)
                        .HasDefaultValueSql("GETUTCDATE()");
                }
            }
        }

    }
}