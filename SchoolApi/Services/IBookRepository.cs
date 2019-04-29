using SchoolApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Services
{
   public interface IBookRepository
    {
        //IEnumerable<Book> GetAllBooks();

        //Book GetBookById(Guid Id);


        Task<IEnumerable<Book>> GetAllBooksAsync();

        Task<Book> GetBookByIdAsync(Guid Id);
    }
}
