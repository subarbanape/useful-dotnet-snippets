using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets
{
    public class Linq_UsersAndRoles
    {
        class User
        {
            public string FirstName;
            public string LastName;
            public string UserName;
            public int Id;
        }

        class Role
        {
            public string Name;
            public int Id;
        }

        class UserAndRole
        {
            public int UserId;
            public int RoleId;
        }

        public static void SomeFunction()
        {
            Role[] roles = new Role[3] {
                new Role(){Id=1, Name="Admin"},
                new Role(){Id=2, Name="User"},
                new Role(){Id=3, Name="Analyst"},
            };

            User[] users = new User[3] {
                new User(){FirstName="John", LastName="Doe", UserName="John.Doe", Id=1},
                new User(){FirstName="Tim", LastName="Niu", UserName="Tim.Niu", Id=2},
                new User(){FirstName="Den", LastName="Kim", UserName="Den.Kim", Id=3},
            };

            UserAndRole[] userAndRoles = new UserAndRole[7] {
                new UserAndRole(){RoleId=1, UserId=1 },
                new UserAndRole(){RoleId=1, UserId=2 },
                new UserAndRole(){RoleId=1, UserId=3 },
                new UserAndRole(){RoleId=2, UserId=1 },
                new UserAndRole(){RoleId=2, UserId=2 },
                new UserAndRole(){RoleId=2, UserId=3 },
                new UserAndRole(){RoleId=3, UserId=1 },
            };

            // problem - get all admin users
            var resut = (from userAndRole in userAndRoles
                         join role in roles on userAndRole.RoleId equals role.Id
                         join user in users on userAndRole.UserId equals user.Id
                         where role.Name == "Admin"
                         select new { userName = user.UserName }
                         );


        }
    }
}
