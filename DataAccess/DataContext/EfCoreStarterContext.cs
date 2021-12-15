using DataAccess.Entitiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataContext
{
    public class EfCoreStarterContext : DbContext
    {
        public EfCoreStarterContext()
        {

        }

        public EfCoreStarterContext(DbContextOptions<EfCoreStarterContext> options): base(options)
        {

        }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=YASITH-PC\\SQLEXPRESS;Database=EFCorePlay;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
