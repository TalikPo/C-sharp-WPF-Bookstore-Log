using DAL.DALContext;
using DAL.DALInterfaces;
using DAL.DALModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DALBookRepository : IMethodsDAL<DALBookModel>
    {
        BookStoreContext _bookStoreContext;
        public DALBookRepository()
        {
            _bookStoreContext = new BookStoreContext();
        }

        public void add(DALBookModel element)
        {
            if (element != null)
            {
                _bookStoreContext.Books.Add(element);
            }

        }

        public void remove(DALBookModel element)
        {
            if (element != null)
            {
                _bookStoreContext.Books.Remove(_bookStoreContext.Books.First(item => item.ID == element.ID));
            }
        }

        public void update(DALBookModel element)
        {
            if (element != null)
            {
                DALBookModel tempo = _bookStoreContext.Books.Where(b => b.ID == element.ID).First();
                if (tempo != null) 
                {
                    tempo.BookName = element.BookName;
                    tempo.BookAuthor.AuthorFirstName = element.BookAuthor.AuthorFirstName;
                    tempo.BookAuthor.AuthorLastName = element.BookAuthor.AuthorLastName;
                    tempo.BookPublishment.PublishmentName = element.BookPublishment.PublishmentName;
                    tempo.BookPublishment.PublishmentYear = element.BookPublishment.PublishmentYear;
                    tempo.PagesAmount = element.PagesAmount;
                    tempo.Genre = element.Genre;
                    tempo.Cost = element.Cost;
                    tempo.Price = element.Price;
                    tempo.isSequel = element.isSequel;
                    tempo.isOnSale = element.isOnSale;
                    tempo.isSold = element.isSold;
                    tempo.isPopular = element.isPopular;
                    tempo.isNew = element.isNew;
                    tempo.isReserved = element.isReserved;
                    tempo.isDiscarded = element.isDiscarded;

                    _bookStoreContext.Books.AddOrUpdate(tempo);
                }
            }
        }
        public IEnumerable<DALBookModel> getAll()
        {
            return _bookStoreContext.Books;
        }

        public void save()
        {
            _bookStoreContext.SaveChanges();
        }
    }
}
