using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model

{
     public class User
    {
        private string _encryptedPassword; 
        private readonly string _key = "simpleKey";

        public string Name { get; set; }
        public string Password {
            get { return Decrypt(_encryptedPassword); } 
            set { _encryptedPassword =Encrypt (value); }
        }
        public int Id { get; set; }
        public UserRolesEnum Role { get; set; }

        public string Email { get; set; }

        private string Encrypt(string input)
        {
            char[] keyChars = _key.ToCharArray();
            char[] inputChars = input.ToCharArray();
            char[] outputChars = new char[input.Length];
            for (int i = 0; i < inputChars.Length; i++)
            {
                outputChars[i] = (char)(inputChars[i] ^ keyChars[i % keyChars.Length]);
            }
            return new string(outputChars);
        }

        private string Decrypt(string input)
        {
            return Encrypt(input); 
        }

    }
           
}
