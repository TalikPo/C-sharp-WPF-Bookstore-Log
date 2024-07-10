using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Книгарня.ViewModel
{
    public class UsersViewModel : ViewModelBase
    {
        private BLLUserModel _users;
        public BLLUserModel Users
        {
            get { return _users; }
            set 
            {
                _users = value; 
                OnPropertyChanged();
            }
        }
    }
}
