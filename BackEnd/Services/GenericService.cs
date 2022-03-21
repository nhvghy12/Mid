
using BackEnd.Data.Entities;
using BackEnd.Data.Repositories;

namespace BackEnd.Services;
public class GenericService<T> : IGenericService<T> where T : BaseEntity
{
    // private readonly MyDbContext? _context;
    // private DbSet<T>? _entities;
    public readonly IGenericRepository<T> _repository;

    public GenericService(IGenericRepository<T> repository)
    {
        _repository = repository;
    }
    public async Task<IList<T?>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();
        return data.ToList();

    }

    public async Task<T?> GetOneAsync(int id)
    {
        if (_repository == null) return null;
        return await _repository.GetAsync(id);
    }

    public async Task<T?> AddAsync(T entity)
    {
        if (_repository == null) return null;

        return await _repository.InsertAsync(entity);

    }

    public async Task<T?> EditAsync(T entity)
    {
        return await _repository.UpdateAsync(entity);
    }

    public async Task RemoveAsync(T entity)
    {
        await _repository.DeleteAsync(entity);
    }
}
