using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CategoryApp.Business.Abstract;
using CategoryApp.Business.Concrete;
using CategoryApp.DataAccess.Concrete.EntityFramework;
using CategoryApp.DataAccess.Concrete.EntityFramework.Contexts;

namespace CategoryApp.Web.UI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
        }
        // GET: Category
        public ActionResult Index()
        {
            return View(_categoryService.GetList(null));
        }

        //public ActionResult TreeView()
        //{
        //    using (CategoryAppContext context = new CategoryAppContext())
        //    {
        //        return View(context.Categories.Where(x => !x.CategoryId.HasValue).ToList());
        //    }
        //}
    }
}