using BLL.Models;
using BLL.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace Книгарня.View
{
    /// <summary>
    /// Interaction logic for EdittingRemovingAccount.xaml
    /// </summary>
    public partial class EdittingRemovingAccount : Window
    {
        LoginPasswordServices lps;
        ObservableCollection<BLLUserModel> users;

        public EdittingRemovingAccount()
        {
            InitializeComponent();
            lps = new LoginPasswordServices();
            lps.getAllfromDB();
            usersListDG.ItemsSource = users;
        }

        private void editBookBTTN_Click(object sender, RoutedEventArgs e)
        {
            lps.update(sender as BLLUserModel);
        }

        private void deleteBookBTTN_Click(object sender, RoutedEventArgs e)
        {
            lps.remove(sender as BLLUserModel);
        }
    }
}
