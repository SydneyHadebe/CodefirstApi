using Microsoft.AspNetCore.Mvc;
using SchoolApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookRepository _repository;
        public BooksController(IBookRepository repository)
        {
           _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            //_context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _repository.GetAllBooksAsync();
            return Ok(books);
        }

    }
}
