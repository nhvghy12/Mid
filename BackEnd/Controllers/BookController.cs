

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
public class BookController : ControllerBase
{
    private readonly IBookService _book;
    private readonly ILogger<BookController> _logger;
    public BookController(ILogger<BookController> logger, IBookService book)
    {
        _logger = logger;
        _book = book;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var data = await _book.GetAllAsync();
        var resultBook = from item in data
                      select new BookViewModel
                      {
                          Id = item.Id,
                          Name = item.Name,
                          Author = item.Author,
                          Summary = item.Summary,
                          CategoryId = item.CategoryId
                      };
        return new JsonResult(resultBook);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOneAsync(int id)
    {
        var data = await _book.GetOneAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return new JsonResult(new BookViewModel
        {
            Id = data.Id,
            Name = data.Name,
            Author = data.Author,
            Summary = data.Summary,
            CategoryId = data.CategoryId
        });
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync(BookCreateModel model)
    {
        try
        {
            var entity = new Data.Entities.Book
            {
                Name = model.Name,
                Author = model.Author,
                Summary = model.Summary,
                CategoryId = (int)model.CategoryId
            };
            var result = await _book.AddAsync(entity);
            return new JsonResult(result);
        }
        catch (System.Exception ex)
        {

            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditAsync(int id, BookEditModel model)
    {
        try
        {
            var data = await _book.GetOneAsync(id);
            if (data == null) return NotFound();
            
            data.Name = model.Name;
            data.Author = model.Author;
            data.Summary = model.Summary;
            data.CategoryId = (int)model.CategoryId;


            var resultBook= await _book.EditAsync(data);
            return new JsonResult(resultBook);
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
            var data = await _book.GetOneAsync(id);
            if (data == null) return NotFound();
            else
            {
                await _book.RemoveAsync(data);
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
