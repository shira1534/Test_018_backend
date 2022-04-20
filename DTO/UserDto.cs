using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
        public string Mail { get; set; }
        public int? Phone { get; set; }
    }
}
