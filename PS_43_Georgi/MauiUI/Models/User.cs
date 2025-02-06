using System;
using Welcome.Others;

namespace MauiUI.Models
{
    public class User
    {
        public string Names { get; set; }
        public string Password { get; set; }
        public UserRolesEnum Role { get; set; }
        public string Email { get; set; }
        public string Fac_Num { get; set; }
        public virtual int Id { get; set; }
        public DateTime Expires { get; set; }
    }
}
