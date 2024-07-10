using BLL.Models;
using BLL.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Книгарня.View;
using Книгарня.ViewModel;

namespace Книгарня.AppUI.View
{
    public partial class MainWindow : Window
    {
        private bool isMax;
        private bool isSalesBTTNon;
        private bool isNewBooksBTTNon;
        private bool isAllBooksBTTNon;
        private bool isReservedBooksBTTNon;
        private bool isPopBooksBTTNon;

        BookstoreServices _bookstoreServices;
        public MainWindow(string userName)
        {
            InitializeComponent();
            isMax = false;
            _bookstoreServices = new BookstoreServices();
            booksListDG.ItemsSource = _bookstoreServices.returnAll();
            userDispalyNameTbl.Text = userName;
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            booksListDG.SelectedItem = null;
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();

            if(e.ClickCount == 2)
            {
                if(isMax == true)
                {
                    this.WindowState = WindowState.Normal;
                    isMax = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    isMax = true;
                }
            }
        }
        private void setButtonsOff()
        {
            isSalesBTTNon = false;
            isNewBooksBTTNon = false;
            isAllBooksBTTNon = false;
            isReservedBooksBTTNon = false;
            isPopBooksBTTNon = false;
        }
        
        private void addBookBTTN_Click(object sender, RoutedEventArgs e)
        {
            //AddingBookWindow addingBookWindow = new AddingBookWindow();
            //addingBookWindow.ShowDialog();
            //viewToModelConnector.returnBookStore().getAllfromDB();
            updateScreenLayout();
        }

        private void editBookBTTN_Click(object sender, RoutedEventArgs e)
        {
            //EditingBookWindow editingBookWindow = new EditingBookWindow((booksListDG.SelectedItem as BLLBookModel));
            //editingBookWindow.ShowDialog();
            updateScreenLayout();
        }

        private void deleteBookBTTN_Click(object sender, RoutedEventArgs e)
        {
            deletion();
            updateScreenLayout();
        }
        
        private void deletion()
        {
            if (isSalesBTTNon)
            {
                (booksListDG.SelectedItem as BLLBookModel).bookState = BookState.None;
                _bookstoreServices.update(booksListDG.SelectedItem as BLLBookModel);
            }
            if (isNewBooksBTTNon)
            {
                (booksListDG.SelectedItem as BLLBookModel).bookState = BookState.None;
                _bookstoreServices.update(booksListDG.SelectedItem as BLLBookModel);
            }
            if (isAllBooksBTTNon)
            {
                _bookstoreServices.remove(booksListDG.SelectedItem as BLLBookModel);
            }
            if (isReservedBooksBTTNon)
            {
                (booksListDG.SelectedItem as BLLBookModel).bookState = BookState.None;
                _bookstoreServices.update(booksListDG.SelectedItem as BLLBookModel);
            }
            if (isPopBooksBTTNon)
            {
                (booksListDG.SelectedItem as BLLBookModel).bookState = BookState.None;
                _bookstoreServices.update(booksListDG.SelectedItem as BLLBookModel);
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _bookstoreServices.saveChanges();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void searchingTbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                booksListDG.ItemsSource = null;
                List<BLLBookModel> tempo = new List<BLLBookModel>();
                foreach (var item in _bookstoreServices.returnAll())
                {
                    if(item.BookName.Contains(searchingTbx.Text))
                        tempo.Add(item);
                } 
                booksListDG.ItemsSource = tempo;
            }
        }

        private void addToSalesBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (booksListDG.SelectedItem != null)
            {
                (booksListDG.SelectedItem as BLLBookModel).bookState = BookState.OnSale;
                DiscountWindow discount = new DiscountWindow();
                discount.ShowDialog();
                (booksListDG.SelectedItem as BLLBookModel).Price -= ((booksListDG.SelectedItem as BLLBookModel).Price / 100 * discount.returnDiscount());
                //viewToModelConnector.returnBookStore().update((booksListDG.SelectedItem as BLLBookModel));
                MessageBox.Show("Книгу додано до акцій");
            }
        }

        private void discardBookBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (booksListDG.SelectedItem != null)
            {
                (booksListDG.SelectedItem as BLLBookModel).bookState = BookState.Discard;
                _bookstoreServices.update(booksListDG.SelectedItem as BLLBookModel);
                MessageBox.Show("Книгу списано");
            }
        }

        private void reserveBookBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (booksListDG.SelectedItem != null)
            {
                (booksListDG.SelectedItem as BLLBookModel).bookState = BookState.Reserved;
                _bookstoreServices.update(booksListDG.SelectedItem as BLLBookModel);
                MessageBox.Show("Книгу зарезервовано");
            }
        }

        private void sellBookBTTN_Click(object sender, RoutedEventArgs e)
        {
            if (booksListDG.SelectedItem != null)
            {
                (booksListDG.SelectedItem as BLLBookModel).bookState = BookState.Sold;
                (booksListDG.SelectedItem as BLLBookModel).PagesAmount -= 1;
                _bookstoreServices.update(booksListDG.SelectedItem as BLLBookModel);
                MessageBox.Show("Книгу продано");
            }
        }

        private void salesBTTN_Click(object sender, RoutedEventArgs e)
        {
            booksListDG.ItemsSource = _bookstoreServices.returnAll().Where(elem => elem.bookState == BookState.OnSale).ToList();
            setButtonsOff();
            isSalesBTTNon = true;
        }
        private void newBooksBTTN_Click(object sender, RoutedEventArgs e)
        {
            booksListDG.ItemsSource = _bookstoreServices.returnAll().Where(elem => elem.bookState == BookState.NewBook).ToList();
            setButtonsOff();
            isNewBooksBTTNon = true;
        }
        private void allBooksBTTN_Click(object sender, RoutedEventArgs e)
        {
            booksListDG.ItemsSource = _bookstoreServices.returnAll();
            setButtonsOff();
            isAllBooksBTTNon = true;
        }
        private void reservedBooksBTTN_Click(object sender, RoutedEventArgs e)
        {
            booksListDG.ItemsSource = _bookstoreServices.returnAll().Where(elem => elem.bookState == BookState.Reserved).ToList();
            setButtonsOff();
            isReservedBooksBTTNon = true;
        }
        private void popBooksBTTN_Click(object sender, RoutedEventArgs e)
        {
            booksListDG.ItemsSource = _bookstoreServices.returnAll().Where(elem => elem.bookState == BookState.Popular).ToList();
            setButtonsOff();
            isPopBooksBTTNon = true;
        }

        private void booksListDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (booksListDG.SelectedItem != null)
            {
                addToSalesBTTN.IsEnabled = true;
                discardBookBTTN.IsEnabled = true;
                reserveBookBTTN.IsEnabled = true;
                sellBookBTTN.IsEnabled = true;
            }
            else
            {
                addToSalesBTTN.IsEnabled = false;
                discardBookBTTN.IsEnabled = false;
                reserveBookBTTN.IsEnabled = false;
                sellBookBTTN.IsEnabled = false;
            }
        }
        private void updateScreenLayout()
        {
            booksListDG.ItemsSource = null;
            booksListDG.ItemsSource = _bookstoreServices.returnAll();
        }
        private void exitBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void registartionTbl_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow rw = new RegistrationWindow();
            rw.ShowDialog();
        }

        private void edittingTbl_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            EdittingRemovingAccount era = new EdittingRemovingAccount();
            era.ShowDialog();
        }
    }
}
