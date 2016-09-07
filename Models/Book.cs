using System;

namespace BookService.Models
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; set;}
        public Double Price { get; set;}
        public Book(string title, Double price)
        {
            try
            {
                Id = Program.NextId++;
                Title = title;
                Price = price;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        override public int GetHashCode()
        {
            return Id;
        }
    }
}
