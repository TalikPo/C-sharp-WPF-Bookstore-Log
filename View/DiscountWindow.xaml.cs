using System;
using System.Windows;
using System.Windows.Input;
using Книгарня.ViewModel;

namespace Книгарня.View
{
    /// <summary>
    /// Interaction logic for Discount.xaml
    /// </summary>
    public partial class DiscountWindow : Window
    {
        int a;
        ViewModelBase win;
        public DiscountWindow()
        {
            InitializeComponent();
            //win = w;
        }

        private void discountBttn_Click(object sender, RoutedEventArgs e)
        {
            Int32.TryParse(discountTbx.Text, out a);
        }

        public int returnDiscount()
        {
            return a;
        }

        private void discountBttn_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }
    }
}
