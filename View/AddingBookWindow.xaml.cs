using BLL.Models;
using System;
using System.Windows;
using Книгарня.ViewModel;

namespace Книгарня
{
    /// <summary>
    /// Interaction logic for AddingBookWindow.xaml
    /// </summary>
    public partial class AddingBookWindow : Window
    {
        ViewModelBase viewToModelConnector;
        int intNumbers;
        float floatNumbers;
        public AddingBookWindow(ViewModelBase vTmCnnctr)
        {
            InitializeComponent();
            viewToModelConnector = vTmCnnctr;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            adding();
            MessageBox.Show("Книгу додану");
            clearing();
        }
        private void adding()
        {
            BLLBookModel tempBook = new BLLBookModel();
            BLLAuthorModel tempAuthor = new BLLAuthorModel();
            BLLPublishmentModel tempPublishment = new BLLPublishmentModel();

            tempBook.BookName = bookNameTBL.Text;
            tempAuthor.AuthorFirstName = authorNameTBL.Text;
            tempAuthor.AuthorLastName = authorSurnameTBL.Text;
            tempBook.BookAuthor = tempAuthor;
            tempBook.Genre = genreTBL.Text;
            tempPublishment.PublishmentName = publisherTBL.Text;

            if (Int32.TryParse(yearTBL.Text, out intNumbers))
                tempPublishment.PublishmentYear = intNumbers;
            else
                tempPublishment.PublishmentYear = 0;

            tempBook.BookPublishment = tempPublishment;

            if (Int32.TryParse(pagesNoTBL.Text, out intNumbers))
                tempBook.PagesAmount = intNumbers;
            else
                tempBook.PagesAmount = 0;

            if (float.TryParse(costTBL.Text, out floatNumbers))
                tempBook.Cost = floatNumbers;
            else
                tempBook.Cost = 0;

            if (float.TryParse(priceTBL.Text, out floatNumbers))
                tempBook.Price = floatNumbers;
            else
                tempBook.Price = 0;

            if (!string.IsNullOrEmpty(sequelTBL.Text))
            {
                (sequelTBL.Text).Trim(' ', ',', '.');

                if ((sequelTBL.Text).ToLower() == "так")
                    tempBook.isSequel = true;
                else if ((sequelTBL.Text).ToLower() == "ні")
                    tempBook.isSequel = false;
            }
            else tempBook.isSequel = false;

            //viewToModelConnector.returnBookStore().add(tempBook);
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //viewToModelConnector.returnBookStore().saveChanges();
        }
    }
}
