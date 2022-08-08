using Library.Domain.DTO.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Interfaces
{
    public interface IBookService
    {
        Task<List<GetBooksDTO>> GetBooksAsync(string order);
        Task<List<GetBooksDTO>> GetTop10BooksAsync(string genre);
        Task<GetBookDTO> GetBookAsync(int id);
        Task<bool> DeleteBookAsync(int id, string secret);
        Task<int> SaveBookAsync(SaveBookDTO model);
    }
}
