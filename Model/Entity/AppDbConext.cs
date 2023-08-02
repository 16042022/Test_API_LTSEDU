using Microsoft.EntityFrameworkCore;

namespace Test_API_LTSEDU.Model.Entity
{
    public class AppDbConext : DbContext
    {
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Properties> Properties { get; set; }
        public virtual DbSet<PropertyDetails> PropertyDetails { get; set; }
        public virtual DbSet<ProductDetails> ProductDetails { get; set; }
        public virtual DbSet<ProductDetailPropertyDetails> ProductDetailPropertyDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=DESKTOP-S0F2NJ3;Database=QLyDonHang_API_Test;" +
                $"Trusted_Connection=True;Encrypt=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDetails>()
                .HasOne(pd => pd.Parent)
                .WithMany(pd => pd.Children)
                .HasForeignKey(pd => pd.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ProductDetailPropertyDetails>()
                .HasOne(pdpd => pdpd.PropertyDetails)
                .WithMany(pd => pd.ProductDetailPropertyDetails)
                .HasForeignKey(pdpd => pdpd.PropertyDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
