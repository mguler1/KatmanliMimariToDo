using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        public List<AppUser> GetirAdminOlmayanlar()
        {
            using var context = new TodoContext();
         return  context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join
            (context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,

           (resultTable, resultRole) => new
           {
               user = resultTable.user,
               userRoles = resultTable.userRole,
               roles = resultRole
           }).Where(x => x.roles.Name == "Member").Select(x => new AppUser()
           {
               Id = x.user.Id,
               Name = x.user.Name,
               Surname = x.user.Surname,
               Email = x.user.Email,
               UserName=x.user.UserName
           }).ToList();

        }
        public List<AppUser> GetirAdminOlmayanlar(string aranacakKelime,int aktifSayfa=1)
        {
            using var context = new TodoContext();
            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join
               (context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,

              (resultTable, resultRole) => new
              {
                  user = resultTable.user,
                  userRoles = resultTable.userRole,
                  roles = resultRole
              }).Where(x => x.roles.Name == "Member").Select(x => new AppUser()
              {
                  Id = x.user.Id,
                  Name = x.user.Name,
                  Surname = x.user.Surname,
                  Email = x.user.Email,
                  UserName = x.user.UserName
              });
            if (!string.IsNullOrWhiteSpace(aranacakKelime))
            {
             result = result.Where(x => x.Name.ToLower().Contains(aranacakKelime.ToLower()) || x.Surname.ToLower().Contains(aranacakKelime.ToLower()));
            }
          result=  result .Skip((aktifSayfa-1) *3).Take(3);
            return result.ToList();
        }
    }
}
   
