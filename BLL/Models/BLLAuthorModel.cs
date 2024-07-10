using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class BLLAuthorModel
    {
        public int Id { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public override string ToString()
        {
            return $"{AuthorFirstName} {AuthorLastName}";
        }
    }
}
