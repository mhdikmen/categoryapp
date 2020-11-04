using CategoryApp.Core.DataAccess.EntityFramework;
using CategoryApp.DataAccess.Abstract;
using CategoryApp.DataAccess.Concrete.EntityFramework.Contexts;
using CategoryApp.Entities.Concrete;

namespace CategoryApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CategoryAppContext>, IUserDal
    {
    }
}
