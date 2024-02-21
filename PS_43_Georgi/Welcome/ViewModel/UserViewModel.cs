using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel
{
    class UserViewModel
    {
        private User _user;

        UserViewModel(User user)
        {
            _user = user;
        }
        public User User { get { return _user; } }
        public string Name {get; set; }
        public string Password { get;set; }
        public UserRolesEnum Role { get; set; }
    }
}