using DAL.DALModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class BLLBookModel
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public BLLAuthorModel BookAuthor { get; set; }
        public BLLPublishmentModel BookPublishment { get; set; }
        public int PagesAmount { get; set; }
        public string Genre { get; set; }
        public float Cost { get; set; }
        public float Price { get; set; }
        public bool isSequel { get; set; }
        public BookState bookState { get; set; }
    }
}
