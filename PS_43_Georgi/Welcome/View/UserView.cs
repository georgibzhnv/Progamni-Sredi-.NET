using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    class UserView
    {
        private UserViewModel _viewModel;

        UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public UserViewModel ViewModel { get { return _viewModel; } }

        public void Display()
        {
            return "Welcome\n User:"+ 
        }
    }
}
