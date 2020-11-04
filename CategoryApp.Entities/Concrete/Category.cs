using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryApp.Core.Entities;

namespace CategoryApp.Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public virtual Category Parent { get; set; }
        public virtual List<Category> Childs { get; set; }
    }
}
