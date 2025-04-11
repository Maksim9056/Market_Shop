using Market_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Market_Shop.Data
{
    public class Market_ShopDB :DbContext
    {

        public Market_ShopDB(DbContextOptions<Market_ShopDB> options) : base(options) 
        {
        
        }


        public  DbSet<Partners> Partners { get; set; }
        public DbSet<Patners_type> Patners_type { get; set; }
        public DbSet<PartnerProduct> PartnerProduct { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<Product_type> Product_type { get; set; }


        public DbSet<Requst> Requst { get; set; }

        public DbSet<Manager> Manager { get; set; }



    }
}
