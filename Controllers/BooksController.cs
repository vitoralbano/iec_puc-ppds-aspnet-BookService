using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookService.Models;

namespace BookService.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {  
        // GET api/books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return Program.BookList;
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            object book = Program.BookList.Find(x => x.Id == id); 
            if(book != null)
            {
                return Ok(book);  
            } 
            else 
            {
                return BadRequest("It's a trap! Book not found!");
            }
        }

        // POST api/books
        [HttpPost]
        public object Post([FromBody]Book book)
        {
            try
            {
                //book = new Book(book.Title, book.Price);
                Program.BookList.Add(book);
                return Ok(book);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public object Put(int id, [FromBody]Book book)
        {
            Book bookToUpdate = Program.BookList.Find(x => x.Id == id);
            if(bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Price = book.Price;
                return Ok(bookToUpdate);
            }else{
                return BadRequest("There is no book with id '" + id.ToString() + "'.");
            }
            
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            Book book = Program.BookList.Find(x => x.Id == id);
            if(book != null)
            {
                int bookIndex = Program.BookList.IndexOf(book);
                Program.BookList.RemoveAt(bookIndex);
                return Ok(true);
            }else{
                return BadRequest(false);
            }
        }
    }
}
