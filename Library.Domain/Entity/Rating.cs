using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class Rating
    {
        public int Id { get; set; }
        public decimal Score { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
