using System;
using System.Collections.Generic;
using System.Linq;
using CategoryApp.Core.DataAccess.EntityFramework;
using CategoryApp.DataAccess.Abstract;
using CategoryApp.DataAccess.Concrete.EntityFramework.Contexts;
using CategoryApp.Entities.Concrete;

namespace CategoryApp.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, CategoryAppContext>, ICategoryDal
    {
        public List<Category> GetListWithChilds(int? categoryId)
        {
            using (CategoryAppContext context = new CategoryAppContext())
            {
                return categoryId != null
                    ? context.Categories.Include("Childs").Where(x => x.CategoryId == categoryId).ToList()
                    : context.Categories.Include("Childs").Where(x => x.CategoryId == null).ToList();
            }
        }
    }
}
