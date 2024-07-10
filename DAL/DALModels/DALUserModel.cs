using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALModels
{
    [Table("User")]
    public class DALUserModel
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        [Column ("User_Name")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(30)]
        [Column ("User_Password")]
        public string UserPassword { get; set; }
    }
}
