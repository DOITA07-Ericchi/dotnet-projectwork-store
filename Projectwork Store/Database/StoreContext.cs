using Microsoft.EntityFrameworkCore;
using Projectwork_Store.Models;

namespace Projectwork_Store.Database
{
    public class StoreContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sticker> Stickers { get; set; }
        public DbSet<UserPurchase> UserPurchases { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ericchi.moe;Database=ItashaStoreDevelop;User Id=SA;Password=DatabaseCaconeDegenerato;TrustServerCertificate=True");
        }
    }
}
