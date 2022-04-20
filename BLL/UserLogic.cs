using Dal.Models;
using DTO;
using DTO.convertos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public  class UserLogic: IUserLogic
    {
        private ClothesContext _context;
        public UserLogic(ClothesContext context)
        {
            _context = context;
        }

        public UserDto AddUsers(UserDto z)
        {
            try
            {

                z.UserId = 0;
                User zz = UserConvertor.ToUser(z);
                _context.Users.Add(zz);

                _context.SaveChanges();
                return UserConvertor.ToUserDto(zz);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<UserDto> GetAllUsers()
        {
            return UserConvertor.ToUserDtoList(_context.Users.ToList());
        }

        public UserDto GetUsersById(int id)
        {
            try
            {
                return UserConvertor.ToUserDto(_context.Users.FirstOrDefault(o => o.UserId == id));

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool IsExsist(UserDto u)
        {
            var t = _context.Users.FirstOrDefault(o => o.Mail == u.Mail);

            if (t != null)
            {
                return true;

            }
            else { return false; }



        }

        public UserDto Login(string mail, int pasword)
        {
            var t = _context.Users.FirstOrDefault(o => o.Mail == mail && o.Password == pasword);
            return UserConvertor.ToUserDto(t);
        }

        public UserDto update(UserDto uzer)
        {

            //UsersDto uz = GetUsersById(uzer.Id);
            //if (uzer.Name != "")
            //{
            //   uz.Name = uzer.Name;



            //}
            _context.Users.Update(UserConvertor.ToUser(uzer));
            _context.SaveChanges();

            return uzer;







        }
        public UserDto Register(UserDto u)
        {
            var t = UserConvertor.ToUser(u);
            _context.Users.Add(t);
            _context.SaveChanges();



            return UserConvertor.ToUserDto(t);
        }

        public UserDto Edit(UserDto u)
        {
            var t = UserConvertor.ToUser(u);
            var Et = _context.Users.FirstOrDefault(use => use.UserId == u.UserId);
            if (Et != null)
            {
                Et.Mail = u.Mail;
                Et.UserName = u.UserName;
                Et.Password = u.Password;
                Et.Phone = u.Phone;
                _context.SaveChanges();


            }
            return u;


        }







    }
}
