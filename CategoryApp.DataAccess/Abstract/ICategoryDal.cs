using System.Collections.Generic;
using CategoryApp.Core.DataAccess;
using CategoryApp.Entities.Concrete;

namespace CategoryApp.DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        List<Category> GetListWithChilds(int? categoryId);
    }
}
