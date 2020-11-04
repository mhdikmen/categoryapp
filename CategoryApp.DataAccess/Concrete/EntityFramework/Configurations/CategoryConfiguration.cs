using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CategoryApp.Entities.Concrete;

namespace CategoryApp.DataAccess.Concrete.EntityFramework.Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Categories");

            HasKey(x => x.Id);
            HasIndex(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CategoryId).HasColumnName("CategoryId");
            Property(x => x.Name).HasColumnName("Name");

            HasMany(x => x.Childs).WithOptional(x => x.Parent).HasForeignKey(x => x.CategoryId);
        }
    }
}
