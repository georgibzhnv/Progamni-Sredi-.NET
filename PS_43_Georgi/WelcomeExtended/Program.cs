using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using WelcomeExtended.Others;
namespace WelcomeExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            UserData userData = new UserData();
            User user = new User
            {
                Name = "Georgi",
                Password = "121221111",
                Role = UserRolesEnum.STUDENT
            };

            UserData.AddUser(user);

        }
    }
}