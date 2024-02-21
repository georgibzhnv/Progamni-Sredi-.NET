using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
     class User
    {
        string Name, Password;
        UserRolesEnum Role;
        public string Name { get; set; }
        public int Passoword { get; set; }
        public UserRolesEnum Roles { get; set; }
    }
}
