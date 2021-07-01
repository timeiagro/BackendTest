using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class BookSpecifications
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public List<Book> GetBookBySpecifications(List<Book> books, string Specifications)
        {
            List<Book> bookscontains = new List<Book>();
            return books.FindAll(b => 
            b.Specifications.Author.Contains(Specifications) ||
            b.Specifications.Genres.Contains(Specifications) ||
            b.Specifications.Illustrator.Contains(Specifications) ||
            b.Name.Contains(Specifications) 
            );
        }
    }
}
