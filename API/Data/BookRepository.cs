using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Book>> GetBookByNameAsync(string bookname)
        {
            
            return await _context.Books.Where(x=>x.BookName==bookname).ToListAsync();
        }

        public async Task<PagedList<Book>> GetBooksAsync(UserParams userParams)
        {
            var query=_context.Books.AsNoTracking();
            return await PagedList<Book>.CreateAsync(query,userParams.PageNumber,userParams.PageSize);
           //return await _context.Books.ToListAsync();
        }
    }
}