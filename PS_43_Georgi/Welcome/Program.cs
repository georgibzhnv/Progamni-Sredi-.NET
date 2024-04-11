using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    class Program
    {
        static void Main(string[] args)
        {


            User user = new User
            {
                Name = "Georgi",
                Password = "121221111",
                Role = UserRolesEnum.STUDENT,
                Email = "gbozhinov17@gmail.com"
            };

            UserViewModel userViewModel = new UserViewModel(user);
            UserView userView = new UserView(userViewModel);
            userView.Display();
            userView.DisplayEmail();

        }
    }
}