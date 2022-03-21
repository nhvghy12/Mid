

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using global::BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;

namespace BackEnd.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _category;
    private readonly ILogger<CategoryController> _logger;
    public CategoryController(ILogger<CategoryController> logger, ICategoryService category)
    {
        _logger = logger;
        _category = category;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var data = await _category.GetAllAsync();
        var results = from item in data
                      select new CategoryViewModel
                      {
                          Id = item.Id,
                          Name = item.Name,
                        //   Books = from b in item.Books
                        //   select new BookViewModel
                        //   {
                        //       Name = b.Name
                        //   }
                      };
        return new JsonResult(results);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOneAsync(int id)
    {
        var data = await _category.GetOneAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return new JsonResult(new CategoryViewModel
        {
            Id = data.Id,
            Name = data.Name,
        });
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CategoryCreateModel model)
    {
        try
        {
            var entity = new Data.Entities.Category
            {
                Name = model.Name,

            };
            var resultCategory = await _category.AddAsync(entity);
            return new JsonResult(resultCategory);
        }
        catch (System.Exception ex)
        {

            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditAsync(int id, CategoryEditModel model)
    {
        try
        {
            var data = await _category.GetOneAsync(id);
            if (data == null) return NotFound();
            
            data.Name = model.Name;


            var resultCategory = await _category.EditAsync(data);
            return new JsonResult(resultCategory);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }


    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        try
        {
            var data = await _category.GetOneAsync(id);
            if (data == null) return NotFound();
            else
            {
                await _category.RemoveAsync(data);
                return Ok();
            }
        }

        catch (IndexOutOfRangeException ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }
}
