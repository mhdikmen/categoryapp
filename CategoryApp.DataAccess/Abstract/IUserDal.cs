using CategoryApp.Core.DataAccess;
using CategoryApp.Entities.Concrete;

namespace CategoryApp.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
    }
}
