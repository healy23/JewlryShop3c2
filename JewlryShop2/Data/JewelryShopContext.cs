using JewlryShop2.Models;
using Microsoft.EntityFrameworkCore;

namespace JewlryShop2.Data
{
    public class JewelryContext : DbContext
    {
        public JewelryContext(DbContextOptions<JewelryContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Jewelry> Jewelrys { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<JewelryInPurchase> JewelryInPurchases { get; set; }


    }
}
