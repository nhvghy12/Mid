using BackEnd.Data.Entities;
using BackEnd.Data.Repositories;

namespace BackEnd.Services;
public interface IBookService : IGenericService<Book>
{

}
public class BookService : GenericService<Book>, IBookService
{
    public BookService(IBookRepository book) : base(book)
    {
    }

}