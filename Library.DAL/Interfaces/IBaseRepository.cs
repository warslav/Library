using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        IQueryable<T> GetAll();
        Task DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
