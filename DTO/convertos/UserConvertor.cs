using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.convertos
{
   public class UserConvertor
    {
        public static UserDto ToUserDto(User z)
        {
            return new UserDto()
            {
                UserId=z.UserId,
                 UserName=z.UserName,
                Mail = z.Mail,
                Password = (int)z.Password,
                Phone = z.Phone
            };
        }

        public static User ToUser(UserDto z)
        {
            return new User()
            {
                UserId = z.UserId,
                UserName = z.UserName,
                Mail = z.Mail,
                Password = z.Password,
                Phone = z.Phone
            };
        }
        public static List<UserDto> ToUserDtoList(List<User> z)
        {
            List<UserDto> zlist = new List<UserDto>();

            foreach (var item in z)
            {
                zlist.Add(ToUserDto(item));
            }
            return zlist;
        }
        public static List<User> ToUserList(List<UserDto> z)
        {
            List<User> zlist = new List<User>();

            foreach (var item in z)
            {
                zlist.Add(ToUser(item));
            }
            return zlist;
        }
    }
}
