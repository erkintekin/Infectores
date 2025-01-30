using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        Task Create(T p);
        IQueryable<T> List { get; }
        Task Update(T p);
        Task Delete(T p);
    }
}