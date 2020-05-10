using Microsoft.EntityFrameworkCore;

namespace FlowerShops.Models
{
    public class FlowerShopsContext : DbContext
    {
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<TypeOfGood> TypeOfGoods { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<ShopTypes> ShopTypes { get; set; }

        public FlowerShopsContext(DbContextOptions<FlowerShopsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
