

using BackEnd.Data.Entities;

namespace BackEnd.Services;

public interface IGenericService<T> where T : BaseEntity
{

    Task<IList<T?>> GetAllAsync();

    Task<T?> GetOneAsync(int id);

    Task<T?> AddAsync(T entity);

    Task<T?> EditAsync(T entity);

    Task? RemoveAsync(T entity);
}

