using BECrudAngular_NETCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BECrudAngular_NETCore.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<Traduccion>> GetByIdiomaAsync(string lang);
    }
}