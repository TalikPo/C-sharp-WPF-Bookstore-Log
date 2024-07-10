using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALModels
{
    [Table("Publishment")]
    public class DALPublishmentModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Publishment_Name")]
        public string PublishmentName { get; set; }

        [Required]
        [Column("Publishment_Year")]
        public int PublishmentYear { get; set; }
    }
}
