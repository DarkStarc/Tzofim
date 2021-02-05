using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Tzofim.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<News> News { get; set; }

        public DbSet<CultureForNews> Cultures { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
