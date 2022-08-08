using AutoMapper;
using Library.DAL.Interfaces;
using Library.Domain.DTO.Rating;
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
    public class RatingService : IRatingService
    {
        private readonly IBaseRepository<Rating> _ratingRepository;
        private readonly IBaseRepository<Book> _bookRepository;
        private readonly IMapper _mapper;
        public RatingService(IBaseRepository<Rating> ratingRepository, IBaseRepository<Book> bookRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<int> SaveRatingAsync(int id, SaveRatingDTO model)
        {
            model.BookId = id;
            var entity = _mapper.Map<SaveRatingDTO, Rating>(model);
            var checkEntity = await _bookRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            Rating rating;
            if (checkEntity is null)
            {
                return -1;
            }
            else
            {
                rating = await _ratingRepository.CreateAsync(entity);
            }
            return rating.Id;
        }
    }
}
