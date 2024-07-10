using BLL.Models;
using BLL.Services;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Книгарня.View
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        LoginPasswordServices lps;
        public RegistrationWindow()
        {
            InitializeComponent();
            lps = new LoginPasswordServices();
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

        private void registrationBttn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginTBx.Text) && !string.IsNullOrEmpty(passwordTBx.Text))
            {
                BLLUserModel user = new BLLUserModel
                {
                    UserName = loginTBx.Text,
                    UserPassword = passwordTBx.Text
                };
                lps.add(user);
            }
            else
            {
                if (string.IsNullOrEmpty(loginTBx.Text))
                    loginTBx.BorderBrush = Brushes.Red;
                if (string.IsNullOrEmpty(passwordTBx.Text))
                    passwordTBx.BorderBrush= Brushes.Red;
            }
        }
    }
}
