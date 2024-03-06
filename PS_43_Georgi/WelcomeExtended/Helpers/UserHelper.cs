using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        public static string toString(this User user) {

            return $"Username: {user.Name}, User Role: {user.Role.ToString()}";
        }
        public static string ValidateCredentials(string name, string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "The username cannot be empty.";
            }
            if (string.IsNullOrEmpty(password))
            {
                return "The password cannot be empty.";
            }
            bool isValidUser = UserData.ValidateUser(name, password);
            if (!isValidUser) {
                return "Invalid username or password.";
            }
            return "Credentials are valid.";
        }
       }
    }
