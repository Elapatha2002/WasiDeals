using Admin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Admin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //---------------Create Table For each Model.Class---------------
        public DbSet<Buyers> Buyers { get; set; } // Model.class- Table name
        public DbSet<Sellers> Sellers { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Auctions> Auctions { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
