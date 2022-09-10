using Microsoft.EntityFrameworkCore;
using App.Data.Entities;
using Microsoft.Extensions.Configuration;
using App.Data.Entities;

namespace App.Data.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
