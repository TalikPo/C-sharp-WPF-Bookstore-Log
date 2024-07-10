using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALModels
{
    [Table("Author")]
    public class DALAuthorModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Column ("First_Name")]
        public string AuthorFirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [Column ("Last_Name")]
        public string AuthorLastName { get; set; }
    }
}
