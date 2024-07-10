using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALModels
{
    [Table("Book")]
    public class DALBookModel
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string BookName { get; set; }

        [Required]
        public virtual DALAuthorModel BookAuthor { get; set; }

        [Required]
        [MaxLength(30)]
        public string Genre { get; set; }

        [Required]
        public virtual DALPublishmentModel BookPublishment { get; set; }

        [Required]
        public int PagesAmount { get; set; }

        [Required]
        public float Cost { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public bool isSequel { get; set; }

        [Required]
        public bool isDiscarded { get; set; }

        [Required]
        public bool isOnSale { get; set; }

        [Required]
        public bool isReserved { get; set; }

        [Required]
        public bool isSold { get; set; }

        [Required]
        public bool isNew { get; set; }

        [Required]
        public bool isPopular { get; set; }
    }
}
