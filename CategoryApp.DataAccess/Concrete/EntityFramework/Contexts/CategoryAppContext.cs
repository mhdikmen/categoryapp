using System.Data.Entity;
using CategoryApp.DataAccess.Concrete.EntityFramework.Configurations;
using CategoryApp.Entities.Concrete;

namespace CategoryApp.DataAccess.Concrete.EntityFramework.Contexts
{
    public class CategoryAppContext : DbContext
    {
        public CategoryAppContext() : base(@"Server=DESKTOP-A8MUS1G\SQLEXPRESS;Database=CategoryApp;Trusted_Connection=True;")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
