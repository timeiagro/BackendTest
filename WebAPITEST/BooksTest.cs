using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWebAPI.Controllers;
using TestWebAPI.Models;

namespace WebAPITEST
{
    [TestClass]
    public class BooksTest
    {
        private BooksController booksController;
        private SortList sortList;
        private BookSpecifications specifications;
        public BooksTest()
        {
            this.specifications = new BookSpecifications();
            this.sortList = new SortList();
            this.booksController = new BooksController();
        }
        [TestMethod]
        public void TestGetAll()
        {
            var testbooks = GetTestBooks();
            var result = this.booksController.GetAll() as List<Book>;
            Assert.AreEqual(testbooks.Count, result.Count);
        }
        [TestMethod]
        public void TestGetPriceShipping()
        {
            var result = this.booksController.GetPriceShipping(1);
            //Teste do Produto 1
            //Preço produto: 10.00
            //percentual = 20.0 / 100.0 = 20%
            //conta do valor do frete: 10.00 + (0,2 * 10.00)
            //valor final = 12
            Assert.AreEqual(12, result);
        }
        [TestMethod]
        public void SortAscOrDescByPrice()
        {
            var option = 2;
            var listaordenada = new List<Book>();
            var response = new List<Book>();
            response = this.booksController.SortAscOrDescByPrice(option) as List<Book>;
            if (option == 1)
            {
                Assert.IsTrue(SortAsc(response));
            }
            else
            {
                Assert.IsTrue(SortDesc(response));
            }

        }
        [TestMethod]
        public void GetBookBySpecifications()
        {
            string Specifications = "Drama";
            var response = new List<Book>();
            response = this.booksController.GetBookBySpecifications(Specifications) as List<Book>;
            Assert.IsTrue(VerifySpecifications(response, Specifications));
        }
        #region PRIVATE METHODS
        private bool VerifySpecifications(List<Book> books, string Specifications)
        {
            foreach (var book in books)
            {
                if (book.Specifications.Author.Contains(Specifications))
                    return true;
                if (book.Specifications.Genres.Contains(Specifications))
                    return true;
                if (book.Specifications.Illustrator.Contains(Specifications))
                    return true;
                if (book.Name.Contains(Specifications))
                    return true;
            }
            return false;
        }
        private List<Book> GetTestBooks()
        {
            var testbooks = new List<Book>();
            testbooks.Add(new Book { });
            testbooks.Add(new Book { });
            testbooks.Add(new Book { });
            testbooks.Add(new Book { });
            testbooks.Add(new Book { });
            return testbooks;
        }
        private bool SortAsc(List<Book> books)
        {
            //menor > maior
            double valorantigo = 0;
            foreach (var book in books)
            {
                if (valorantigo > book.Price)
                {
                    return false;
                }
                valorantigo = book.Price;
            }
            return true;
        }
        private bool SortDesc(List<Book> books)
        {
            double valorantigo = 0;
            foreach (var book in books)
            {
                if (valorantigo != 0)
                {
                    if (valorantigo < book.Price)
                    {
                        return false;
                    }
                }
                valorantigo = book.Price;
            }
            return true;
        }
        #endregion

    }
}
