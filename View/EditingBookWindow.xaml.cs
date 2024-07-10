using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Книгарня.ViewModel;

namespace Книгарня.View
{
    /// <summary>
    /// Interaction logic for EditingBookWindow.xaml
    /// </summary>
    public partial class EditingBookWindow : Window
    {
        ViewModelBase viewToModelConnector;
        BLLBookModel example;
        int intNumbers;
        float floatNumbers;
        public EditingBookWindow(ViewModelBase vTmCnnctr, BLLBookModel identity)
        {
            InitializeComponent();
            viewToModelConnector = vTmCnnctr;
            example = identity;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            editing();
            MessageBox.Show("Зміни внесено");
            clearing();
            this.Close();
        }
        private void editing()
        {
            if(!string.IsNullOrEmpty(bookNameTBL.Text))
                example.BookName = bookNameTBL.Text;
            if (!string.IsNullOrEmpty(authorNameTBL.Text))
                example.BookAuthor.AuthorFirstName = authorNameTBL.Text;
            if (!string.IsNullOrEmpty(authorSurnameTBL.Text))
                example.BookAuthor.AuthorLastName = authorSurnameTBL.Text;
            if (!string.IsNullOrEmpty(genreTBL.Text))
                example.Genre = genreTBL.Text;
            if (!string.IsNullOrEmpty(publisherTBL.Text))
                example.BookPublishment.PublishmentName = publisherTBL.Text;

            if (Int32.TryParse(yearTBL.Text, out intNumbers))
                example.BookPublishment.PublishmentYear = intNumbers;

            if (Int32.TryParse(pagesNoTBL.Text, out intNumbers))
                example.PagesAmount = intNumbers;

            if (float.TryParse(costTBL.Text, out floatNumbers))
                example.Cost = floatNumbers;

            if (float.TryParse(priceTBL.Text, out floatNumbers))
                example.Price = floatNumbers;

            if (!string.IsNullOrEmpty(sequelTBL.Text))
            {
                if (sequelTBL.Text == "так")
                    example.isSequel = true;
                else if (sequelTBL.Text == "ні")
                    example.isSequel = false;
            }

            //viewToModelConnector.returnBookStore().update(example);
        }
        private void clearing()
        {
            bookNameTBL.Text = string.Empty;
            authorNameTBL.Text = string.Empty;
            authorSurnameTBL.Text = string.Empty;
            genreTBL.Text = string.Empty;
            publisherTBL.Text = string.Empty;
            yearTBL.Text = string.Empty;
            pagesNoTBL.Text = string.Empty;
            costTBL.Text = string.Empty;
            priceTBL.Text = string.Empty;
            sequelTBL.Text = string.Empty;
        }
    }
}
