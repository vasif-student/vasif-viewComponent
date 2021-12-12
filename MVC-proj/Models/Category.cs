using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_proj.Models
{
    public class Category : BasicEntity
    {
        public List<Product> Products { get; set; }
    }
}
