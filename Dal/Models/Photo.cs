using System;
using System.Collections.Generic;

#nullable disable

namespace Dal.Models
{
    public partial class Photo
    {
        public int Id { get; set; }
        public int? IdClothe { get; set; }
        public string Routing { get; set; }

        public virtual Product IdClotheNavigation { get; set; }
    }
}
