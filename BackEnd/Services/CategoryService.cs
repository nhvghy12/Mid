using BackEnd.Data.Entities;
using BackEnd.Data.Repositories;

namespace BackEnd.Services;
public interface ICategoryService : IGenericService<Category>
{

}
public class CategoryService : GenericService<Category>, ICategoryService
{
    public CategoryService(ICategoryRepository category) : base(category)
    {
    }

}