using NumbersSite.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NumbersSite.DAL
{
    public class NumbersContext : DbContext
    {
        public NumbersContext() : base("NumbersContext")
        {
        }

        public DbSet<Numbers> Numbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}