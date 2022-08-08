using Library.Domain.DTO.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Interfaces
{
    public interface IReviewService
    {
        Task<int> SaveReviewAsync(int id, SaveReviewDTO model);
    }
}
