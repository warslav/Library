using AutoMapper;
using Library.DAL.Interfaces;
using Library.DAL.Repositories;
using Library.Domain.DTO.Book;
using Library.Domain.Entity;
using Library.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Library.Service.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBaseRepository<Book> _bookRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public BookService(IBaseRepository<Book> bookRepository, IMapper mapper, IConfiguration configuration)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<List<GetBooksDTO>> GetBooksAsync(string order)
        {
            order = order.ToLower() == "author" || order.ToLower() == "title" ? order : "id";
            return _mapper.Map<List<GetBooksDTO>>(await _bookRepository.GetAll()
                .Include(b => b.Ratings)
                .Include(b => b.Reviews)
                .OrderBy(order)
                .ToListAsync());
        }

        public async Task<List<GetBooksDTO>> GetTop10BooksAsync(string? genre)
        {
            var result = _mapper.Map<List<GetBooksDTO>>(await _bookRepository.GetAll()
                .Include(b => b.Ratings)
                .Include(b => b.Reviews)
                .Where(b => genre == null || b.Genre.ToLower() == genre.ToLower())
                .OrderByDescending(b => b.Ratings.Count > 0 ? b.Ratings.Average(s => s.Score) : 0)
                .ThenByDescending(b => b.Reviews.Count)
                .Take(10)
                .ToListAsync());
            return result;
        }

        public async Task<GetBookDTO> GetBookAsync(int id)
        {
            var entity = await _bookRepository.GetAll().Include(b => b.Ratings).Include(b => b.Reviews).FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                return _mapper.Map<GetBookDTO>(entity);
            }
            return null;
        }

        public async Task<bool> DeleteBookAsync(int id, string secret)
        {
            if (secret != _configuration["Keys:DeleteKey"])
            {
                return false;
            }
            var entity = await _bookRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null)
            {
                return false;
            }

            await _bookRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<int> SaveBookAsync(SaveBookDTO model)
        {
            var entity = _mapper.Map<SaveBookDTO, Book>(model);
            var checkEntity = await  _bookRepository.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);
            Book book;
            if (checkEntity is null)
            {
                book = await _bookRepository.CreateAsync(entity);
            }
            else
            {
                book = await _bookRepository.UpdateAsync(entity);
            }
            return book.Id;
        }
    }
}
