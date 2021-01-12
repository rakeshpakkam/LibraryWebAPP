using API.Entities;
using API.Helpers;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_tests
{
    public class BookRepositoryFake : IBookRepository
    {
        private readonly IEnumerable<Book> books;
        public BookRepositoryFake()
        {
            books = new List<Book>()
            { new Book(){ Id=1,AuthorName="A",Status=0},
                new Book { Id=2,AuthorName="B",Status=1},
                new Book { Id=3,AuthorName="C",Status=1},
                new Book { Id=4,AuthorName="D",Status=0}
            };

            
        }
        public async Task<IEnumerable<Book>> GetBookByNameAsync(string bookname)
        {
            var items = books.AsQueryable();
            return await items.Where(x => x.BookName == bookname).ToListAsync();
        }

        public async Task<PagedList<Book>> GetBooksAsync(UserParams userParams)
        { var items = books.AsQueryable();
            return await PagedList<Book>.CreateAsync(items, userParams.PageNumber, userParams.PageSize);
        }
    }
}
