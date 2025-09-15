using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class InvetoryDbContext : DbContext
    {
        // Just created a constructor 
       
        public InvetoryDbContext(DbContextOptions<InvetoryDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemsCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.ApplyConfigurationsFromAssembly(typeof(InvetoryDbContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
