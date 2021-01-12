using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks([FromQuery]UserParams userParams)
        {
            var books=await _bookRepository.GetBooksAsync(userParams);
            Response.AddPaginationHeader(books.CurrentPage,books.PageSize,
            books.TotalCount,books.TotalPages);
            return Ok(books);
        }
        [HttpGet("{bookname}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByName(string bookname)
        {
            return Ok(await _bookRepository.GetBookByNameAsync(bookname));
        }
    }
}