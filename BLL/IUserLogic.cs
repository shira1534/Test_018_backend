using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public interface IUserLogic
    {
        List<UserDto> GetAllUsers();
        UserDto GetUsersById(int id);
        UserDto AddUsers(UserDto z);

        UserDto update(UserDto z);

        UserDto Login(string mail, int pasword);
        bool IsExsist(UserDto u);
        UserDto Register(UserDto u);
        UserDto Edit(UserDto u);
    }
}
