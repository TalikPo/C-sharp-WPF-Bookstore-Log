using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class BLLPublishmentModel
    {
        public int Id { get; set; }
        public string PublishmentName { get; set; }
        public int PublishmentYear { get; set; }

        public override string ToString()
        {
            return $"{PublishmentName} {PublishmentYear}";
        }
    }
}
