using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryApp.Entities.Concrete;

namespace CategoryApp.Entities.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public virtual List<Category> Childs { get; set; }
    }
}
