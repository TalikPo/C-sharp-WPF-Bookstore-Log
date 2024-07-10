using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Книгарня.AppUI.View;
using Книгарня.View;

namespace Книгарня
{
    /// <summary>
    /// Interaction logic for LogOnWindow.xaml
    /// </summary>
    public partial class LogOnWindow : Window
    {
        RegistryKey _key;
        string subkeyName;
        public LogOnWindow()
        {
            InitializeComponent();
            _key = Registry.CurrentUser;
            subkeyName = "Book_Store";
        }
        private void registrationBttn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }
        private void loginTBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginTBx.Text))
            {
                logTbl.Visibility = Visibility.Collapsed;
            }
            else
            {
                logTbl.Visibility = Visibility.Visible;
            }
        }
        private void passwordTBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordTBx.Text))
                passwordTbl.Visibility = Visibility.Collapsed;
            else
                passwordTbl.Visibility = Visibility.Visible;
        }
        private void logTbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            loginTBx.Focus();
        }
        private void password_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordTBx.Focus();
        }
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void authorizationBttn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginTBx.Text) && !string.IsNullOrEmpty(passwordTBx.Text))
            {
                foreach (var item in Registry.CurrentUser.GetSubKeyNames())
                {
                    if (item == subkeyName)
                    {
                        try
                        {
                            string tem = Registry.CurrentUser.OpenSubKey(item).GetValue(loginTBx.Text).ToString();
                            if (tem == passwordTBx.Text)
                            {
                                MainWindow mainWindow = new MainWindow(loginTBx.Text);
                                mainWindow.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Не вірне ім'я чи пароль", "Помилка входу");
                                break;
                            }
                        }
                        catch(Exception ex) 
                        {
                            MessageBox.Show(ex.Message, "Сталася помилка!");
                        }
                    }
                }
            }
        }
    }
}
