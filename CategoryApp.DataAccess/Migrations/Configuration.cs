using CategoryApp.Entities.Concrete;

namespace CategoryApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CategoryApp.DataAccess.Concrete.EntityFramework.Contexts.CategoryAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CategoryApp.DataAccess.Concrete.EntityFramework.Contexts.CategoryAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //Creating Dummy categories and sub categories  
            context.Categories.AddOrUpdate(c => c.Name,
                new Category { Id = 1, Name = "Elektronik", CategoryId = null},
                new Category { Id = 2, Name = "Bilgisayar", CategoryId = 1 },
                new Category { Id = 3, Name = "Hp Bilgisayar", CategoryId = 2 },
                new Category { Id = 4, Name = "Dell Bilgisayar", CategoryId = 2},
                new Category { Id = 5, Name = "Dizüstü Bilgisayar", CategoryId = 1 },
                new Category { Id = 6, Name = "Hp Pavilion Dv6000", CategoryId = 3 }
            );
        }
    }
}
