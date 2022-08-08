using AutoMapper;
using Library.DAL.Interfaces;
using Library.Domain.DTO.Review;
using Library.Domain.Entity;
using Library.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IBaseRepository<Review> _reviewRepository;
        private readonly IBaseRepository<Book> _bookRepository;
        private readonly IMapper _mapper;
        public ReviewService(IBaseRepository<Review> reviewRepository, IMapper mapper, IBaseRepository<Book> bookRepository)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<int> SaveReviewAsync(int id, SaveReviewDTO model)
        {
            model.BookId = id;
            var entity = _mapper.Map<SaveReviewDTO, Review>(model);
            var checkEntity = await _bookRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            Review review;
            if (checkEntity is null)
            {
                return -1;
            }
            else
            {
                review = await _reviewRepository.CreateAsync(entity);
            }
            return review.Id;
        }
    }
}
