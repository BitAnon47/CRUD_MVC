using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BookController : ControllerBase
	{
		private readonly BookContext _bookContext;
		public BookController(BookContext bookContext)
		{
			_bookContext = bookContext;
		}


		[HttpGet]
		public IActionResult GetAllBooks()
		{
			List<Book>? books = _bookContext.Books?.ToList();
			if (books == null)
			{
				return NotFound();
			}
			return Ok(books);
		}

		[HttpGet("{id}")]
		public IActionResult GetBook(int id)
		{
			Book? book = _bookContext.Books?.FirstOrDefault(b => b.Id == id);
			if (book == null)
			{
				return NotFound();
			}
			return Ok(book);
		}

		[HttpPost]
		[HttpPost]
		[HttpPost]
		public IActionResult AddBook(Book book)
		{
			if (_bookContext == null)
			{
				return BadRequest("Book context is null");
			}

			if (_bookContext.Books == null)
			{
				return BadRequest("Book list is null");
			}

			_bookContext.Books.Add(book);
			_bookContext.SaveChanges();
			return Ok();
		}



		[HttpPut("{id}")]
		public IActionResult UpdateBook(int id, Book book)
		{
Book existingBook = _bookContext.Books?.FirstOrDefault(b => b.Id == id);
if (existingBook == null)
{
    return NotFound();
}




			existingBook.Title = book.Title;
			existingBook.Author = book.Author;
			_bookContext.SaveChanges();
			return Ok();
		}




		[HttpDelete("{id}")]
		public IActionResult DeleteBook(int id)
		{
			Book? existingBook = _bookContext.Books.FirstOrDefault(b => b.Id == id);
			if (existingBook == null)
			{
				return NotFound();
			}
			_bookContext.Books.Remove(existingBook);
			_bookContext.SaveChanges();
			return Ok();
		}
	}
}