using System.Collections.ObjectModel;
using MauiUI.Models;

namespace MauiUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<DataBaseUser> _users;
        public ObservableCollection<DataBaseUser> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Users = new ObservableCollection<DataBaseUser>
            {
                new DataBaseUser { Id = 1, Names = "John Doe", Email = "john@example.com" ,Fac_Num = "121221111" },
                new DataBaseUser { Id = 2, Names = "Jane Doe", Email = "jane@example.com" , Fac_Num= "121221110" }
            };
        }
    }
}
