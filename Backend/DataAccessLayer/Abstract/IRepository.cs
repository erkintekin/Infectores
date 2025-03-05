using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Backend.DataAccessLayer.Abstract
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> List { get; }
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<T> GetByIdAsync(int id);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}