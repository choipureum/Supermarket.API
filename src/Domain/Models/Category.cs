using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //oneToMany 종속성
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
