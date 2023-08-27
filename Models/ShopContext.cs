using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ef
{

    public class ShopContext : DbContext
    {
        public static ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });

        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Category { set; get; }

        private const string connectionString = @"
        Data Source= localhost,1433; 
        Initial Catalog = shopdata; 
        User ID = sa; 
        Password = Password123;
        TrustServerCertificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);

            // optionsBuilder.UseLazyLoadingProxies();
            Console.WriteLine("OnConfiguring");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent Api
            modelBuilder.Entity<Product>(entity =>
            {
                //Table mapping
                entity.ToTable("ProductEntityApi");  // Same as [Table("Product")] for Product model
                entity.HasKey(p => p.ProductId);
                entity.HasIndex(p => p.ProductPrice).HasDatabaseName("index-product-price");
                entity.HasOne(p => p.Category).WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Product_Category");

                entity.HasOne(p => p.Category2)
                        .WithMany(c => c.Products)
                        .HasForeignKey("CategoryId2")
                        .OnDelete(DeleteBehavior.NoAction);

                entity.Property(p => p.ProductName).HasColumnName("ProductNameApi").HasColumnType("nvarchar").HasMaxLength(60).IsRequired(true).HasDefaultValue("Default Product Name");

            });




            Console.WriteLine("OnModelCreating");

        }

    }
}