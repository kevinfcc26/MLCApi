using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Exit(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task DeleteAsync(int id);
        Task<T> Update(int id, T element);
        Task<T> Add(T elemnt);
        Task<T> Update(T element);
    }
}
