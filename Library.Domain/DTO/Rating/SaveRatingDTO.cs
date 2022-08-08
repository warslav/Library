using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.DTO.Rating
{
    public class SaveRatingDTO
    {
        public decimal Score { get; set; }
        public int? BookId { get; set; }
    }
}
