using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CategoryApp.Entities.Concrete;

namespace CategoryApp.DataAccess.Concrete.EntityFramework.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");

            HasKey(x => x.Id);
            HasIndex(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Username).HasColumnName("UserName");
            Property(x => x.Email).HasColumnName("Email");
            Property(x => x.PasswordHash).HasColumnName("PasswordHash");
            Property(x => x.PasswordSalt).HasColumnName("PasswordSalt");
        }
    }
}
