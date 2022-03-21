using BackEnd.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data.Repositories;
public interface IBookRepository : IGenericRepository<Book>
{
    Task<IEnumerable<Book>> GetAllIncludedAsync();
}
public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(MyDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Book>> GetAllIncludedAsync()
    {
        return await _entities.Include(c => c.Details).ToListAsync();
    }
}