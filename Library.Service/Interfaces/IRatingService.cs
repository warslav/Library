using Library.Domain.DTO.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Interfaces
{
    public interface IRatingService
    {
        Task<int> SaveRatingAsync(int id, SaveRatingDTO model);
    }
}
