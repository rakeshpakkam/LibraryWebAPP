using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IBookRepository
    {
         Task<PagedList<Book>> GetBooksAsync(UserParams userParams);
         Task<IEnumerable<Book>> GetBookByNameAsync(string bookname);
    }
}