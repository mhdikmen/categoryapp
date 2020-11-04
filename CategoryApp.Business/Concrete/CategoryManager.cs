using System;
using System.Collections.Generic;
using System.Linq;
using CategoryApp.Business.Abstract;
using CategoryApp.DataAccess.Abstract;
using CategoryApp.DataAccess.Concrete.EntityFramework.Contexts;
using CategoryApp.Entities.Concrete;

namespace CategoryApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetList(int? categoryId)
        {
            var categories = categoryId == null ? _categoryDal.GetListWithChilds(null) : _categoryDal.GetListWithChilds(categoryId);
            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].Childs != null)
                {
                    foreach (var category in categories[i].Childs)
                    {
                        category.Childs = new List<Category>();
                        category.Childs.AddRange(GetList(category.Id));
                    }
                }
            }
            return categories;
        }
    }
}
