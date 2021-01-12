using API.Controllers;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API_tests
{
    public class BooksControllerTest
    {
        BooksController _controller;
        IBookRepository _repository;
        public BooksControllerTest()
        {
            _repository = new BookRepositoryFake();
            _controller = new BooksController(_repository);
        }
        [Fact]
        public async void Get_WhenCalled_ReturnsOkResult()
        {
            UserParams userParams = new UserParams {
                PageNumber = 1,PageSize=5            
            };
            // Act
            var okResult =await _controller.GetBooks(userParams);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public async void Get_WhenCalled_ReturnsBooks()
        {
            UserParams userParams = new UserParams
            {
                PageNumber = 1,
                PageSize = 5
            };
            // Act
            var okResult = await _controller.GetBooks(userParams);
            // Assert
            var items = Assert.IsType<List<Book>>(okResult);
            Assert.Equal(4, items.Count);
        }
    }
}
