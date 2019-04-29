using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Entities;
using SchoolApi.SchoolContext;

namespace SchoolApi.Services
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private BooksContext _context;

        public BookRepository(BooksContext context)
        {
            //if (_context == null)
            //{
            //    throw new ArgumentNullException(nameof(context));
            //}
            //_context = context;

            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.books.Include(a => a.developerAuthor).ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(Guid Id)
        {
            return await _context.books.Include(a => a.AuthorId == Id).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

         
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
