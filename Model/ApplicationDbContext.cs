using E_Commerce_Api.Enums;
using System.Diagnostics;

namespace E_Commerce_Api.Model
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
            .HasOne<Category>()
            .WithMany()
            .HasForeignKey(s => s.CategoryId);
            
            modelBuilder.Entity<Product>()
            .HasOne<Seller>()
            .WithMany()
            .HasForeignKey(s => s.SellerID);

            modelBuilder.Entity<Product>()
            .Property(e => e.DiscountDescription) 
            .IsRequired(false);

            modelBuilder.Entity<Product>()
            .Property(e => e.DiscountPercent) 
            .IsRequired(false);

            //SeedData(modelBuilder);
        }
        
        private void SeedData(ModelBuilder modelBuilder)
        {
           var categories = CategoryType.CategoryTypeList();
            foreach (var category in categories)
            {
                modelBuilder.Entity<Category>().HasData(new Category { Name = category.Name, Description = category.Description });
            }
        }
    }
}
