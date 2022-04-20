using System;
using System.Collections.Generic;

#nullable disable

namespace Dal.Models
{
    public partial class Product
    {
        public Product()
        {
            Photos = new HashSet<Photo>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int? Price { get; set; }
        public int? UnitsInStock { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
