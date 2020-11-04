using System.Collections.Generic;
using CategoryApp.Entities.Concrete;

namespace CategoryApp.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList(int? categoryId);
    }
}
