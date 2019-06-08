using System.Data.Entity;

namespace CarsEntityFramework
{
    class Context : DbContext
    {
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Prices> Prices { get; set; }
    }
   
}
