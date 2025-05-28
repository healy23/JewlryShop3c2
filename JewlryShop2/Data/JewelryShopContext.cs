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

        public DbSet<Review> Reviews { get; set; }


        public DbSet<Cart> Cart { get; set; }
        public DbSet<Item> Item { get; set; }


    }
}
