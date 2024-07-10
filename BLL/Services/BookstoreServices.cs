using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.DALModels;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookstoreServices : IMethodsBLL<BLLBookModel>
    {
        List<BLLBookModel> _books;
        DALBookRepository bookRepository;
        public BookstoreServices()
        {
            _books = new List<BLLBookModel>();
            bookRepository = new DALBookRepository();
            getAllfromDB();
        }
        public void getAllfromDB()
        {
            List<BLLBookModel> tempobooks = new List<BLLBookModel>();
            foreach (DALBookModel item in bookRepository.getAll())
            {
                tempobooks.Add(DALtoBLLtranslation(item));
            }
            _books = null;
            _books = tempobooks;
        }
        public void add(BLLBookModel element)
        {
            _books.Add(element);
            bookRepository.add(BLLtoDALtranslation(element));
        }
        public void remove(BLLBookModel element)
        {
            _books.Remove(element);
            bookRepository.remove(BLLtoDALtranslation(element));
        }
        public void update(BLLBookModel element)
        {
            BLLBookModel tempo = _books.FirstOrDefault(el => el.ID == element.ID);
            if (!string.IsNullOrEmpty(element.BookName)) 
                tempo.BookName = element.BookName;
            if (!string.IsNullOrEmpty(element.BookAuthor.AuthorFirstName))
                tempo.BookAuthor.AuthorFirstName = element.BookAuthor.AuthorFirstName;
            if (!string.IsNullOrEmpty(element.BookAuthor.AuthorLastName))
                tempo.BookAuthor.AuthorLastName = element.BookAuthor.AuthorLastName;
            if (!string.IsNullOrEmpty(element.Genre))
                tempo.Genre = element.Genre;
            if (!string.IsNullOrEmpty(element.BookPublishment.PublishmentName))
                tempo.BookPublishment.PublishmentName = element.BookPublishment.PublishmentName;
            if (element.BookPublishment.PublishmentYear != 0)
                tempo.BookPublishment.PublishmentYear = element.BookPublishment.PublishmentYear;
            if (element.PagesAmount != 0)
                tempo.PagesAmount = element.PagesAmount;
            if (element.Cost != 0)
                tempo.Cost = element.Cost;
            if (element.Price != 0)
                tempo.Price = element.Price;
                
            tempo.isSequel = element.isSequel;
            tempo.bookState = element.bookState;

            bookRepository.update(BLLtoDALtranslation(tempo));
        }
        public List<BLLBookModel> returnAll()
        {
            return _books;
        }
        public void saveChanges()
        {
            bookRepository.save();
        }
        private DALBookModel BLLtoDALtranslation(BLLBookModel model)
        {
            DALBookModel value = new DALBookModel();
            DALAuthorModel tempAuthor = new DALAuthorModel();
            DALPublishmentModel tempPublisher = new DALPublishmentModel();
            value.ID = model.ID;
            value.BookName = model.BookName;
            tempAuthor.AuthorFirstName = model.BookAuthor.AuthorFirstName;
            tempAuthor.AuthorLastName = model.BookAuthor.AuthorLastName;
            value.BookAuthor = tempAuthor;
            value.Genre = model.Genre;
            tempPublisher.PublishmentName = model.BookPublishment.PublishmentName;
            tempPublisher.PublishmentYear = model.BookPublishment.PublishmentYear;
            value.BookPublishment = tempPublisher;
            value.PagesAmount = model.PagesAmount;
            value.Cost = model.Cost;
            value.Price = model.Price;
            value.isSequel = model.isSequel;
            switch(model.bookState)
            {
                case BookState.OnSale:
                    value.isOnSale = true; break;
                case BookState.NewBook:
                    value.isNew = true; break;
                case BookState.Reserved:
                    value.isReserved = true; break;
                case BookState.Discard:
                    value.isDiscarded = true; break;
                case BookState.Popular:
                    value.isPopular = true; break;
                case BookState.Sold:
                    value.isSold = true; break;
            }
            return value;
        }
        private BLLBookModel DALtoBLLtranslation(DALBookModel model)
        {
            BLLBookModel value = new BLLBookModel();
            BLLAuthorModel tempoAuthor = new BLLAuthorModel();
            BLLPublishmentModel tempoPublishmnent = new BLLPublishmentModel();
            value.ID = model.ID;
            value.BookName = model.BookName;
            tempoAuthor.AuthorFirstName = model.BookAuthor.AuthorFirstName;
            tempoAuthor.AuthorLastName = model.BookAuthor.AuthorLastName;
            value.BookAuthor = tempoAuthor;
            value.Genre = model.Genre;
            tempoPublishmnent.PublishmentName = model.BookPublishment.PublishmentName;
            tempoPublishmnent.PublishmentYear = model.BookPublishment.PublishmentYear;
            value.BookPublishment = tempoPublishmnent;
            value.PagesAmount = model.PagesAmount;
            value.Cost = model.Cost;
            value.Price = model.Price;
            value.isSequel = model.isSequel;

            if (model.isOnSale)
                value.bookState = BookState.OnSale;
            else if (model.isReserved)
                value.bookState = BookState.Reserved;
            else if (model.isNew)
                value.bookState = BookState.NewBook;
            else if (model.isDiscarded)
                value.bookState = BookState.Discard;
            else if(model.isPopular)
                value.bookState = BookState.Popular;
            else if(model.isSold)
                value.bookState = BookState.Sold;

            return value;
        }
    }
}
