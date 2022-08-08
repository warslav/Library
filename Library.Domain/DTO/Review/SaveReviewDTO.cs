using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.DTO.Review
{
    public class SaveReviewDTO
    {
        public string Message { get; set; }
        public string Reviewer { get; set; }
        public int? BookId { get; set; }
    }
}
