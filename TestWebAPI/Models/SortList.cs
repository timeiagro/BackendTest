using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SortList
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public List<Book> SortAscByPryce(List<Book> books)
        {
            List<Book> booksasc = (from book in books
                                               orderby book.Price ascending
                                               select book).ToList();
            return booksasc;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public List<Book> SortDescByPryce(List<Book> books)
        {
            List<Book> booksdesc = (from book in books
                                                orderby book.Price descending
                                                select book).ToList();
            return booksdesc;
        }
    }
}
