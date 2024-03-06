using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;
using WelcomeExtended.Others;

namespace WelcomeExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            UserData userData = new UserData(new List<User>(),0);

            User studentUser = new User
            {
                Name = "Georgi",
                Password = "123",
                Role = UserRolesEnum.STUDENT
            };

            User student2User = new User
            {
                Name = "Ivan",
                Password = "121",
                Role = UserRolesEnum.STUDENT
            };

            User teacherUser = new User
            {
                Name = "Ivana",
                Password = "133",
                Role = UserRolesEnum.PROFESSOR
            };

            User adminUser = new User
            {
                Name = "Yordan",
                Password = "111",
                Role = UserRolesEnum.ADMIN
            };

            userData.AddUser(studentUser);
            userData.AddUser(student2User);
            userData.AddUser(teacherUser);
            userData.AddUser(adminUser);

            Console.WriteLine("Моля, въведете потребителско име:");
            string username = Console.ReadLine();
            Console.WriteLine("Моля, въведете парола:");
            string password = Console.ReadLine();

            string validationResponse = UserHelper.ValidateCredentials(username, password, userData); 
            if (validationResponse == "Credentials are valid.")
            {
                User user = userData.GetUser(username, password);
                if (user != null)
                {
                    Console.WriteLine(user.toString());
                    HashLogger.LogSuccess(username);
                }
                else
                {
                    throw new Exception("Потребителят не е намерен");
                }
            }
            else
            {
                Console.WriteLine(validationResponse);
                HashLogger.LogFailure(username,validationResponse);
            }

        }
    }
}