using System;
using System.Collections.Generic;

#nullable disable

namespace Dal.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int? Password { get; set; }
        public string Mail { get; set; }
        public int? Phone { get; set; }
    }
}
