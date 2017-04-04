using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.Contratos
{
    /// <summary>
    /// Contrato generico para las operaciones CRUD async y sync
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {

        int Add(T entity);
        Task<int> AddAsync(T entity);

        int AddRange(List<T> entities);

        Task<int> AddRangeAsync(List<T> entities);

        int Save(T entity);

        Task<int> SaveAsync(T entity);

        T GetOne(int id);

        Task<T> GetOneAsync(int id);

        List<T> GetAll();

        Task<List<T>> GetAllAsync();

        int Delete(T entity);

        Task<int> DeleteAsync(T entity);

        //int Delete(string id);

        //Task<int> DeleteAsync(string id);

    }
}
