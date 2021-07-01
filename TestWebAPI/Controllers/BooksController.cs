using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestWebAPI.Models;

namespace TestWebAPI.Controllers
{
    /// <summary>
    /// Configura a rota
    /// </summary>
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private WebClient wc;
        private SortList sortList;
        private BookSpecifications bookSpecifications;
        private PriceShipping priceShipping;
        private string response;
        private List<Book> books;
        /// <summary>
        /// Construtor da BooksController
        /// </summary>
        public BooksController()
        {
            this.sortList = new SortList();
            this.bookSpecifications = new BookSpecifications();
            this.priceShipping = new PriceShipping();
            this.wc = new WebClient();
            this.wc.Encoding = Encoding.UTF8;
            this.response = this.wc.DownloadString("https://raw.githubusercontent.com/timeiagro/BackendTest/main/books.json");
            this.books = JsonConvert.DeserializeObject<List<Book>>(this.response);
        }
        /// <summary>
        /// Busca Todos os Livros.
        /// </summary>
        /// <returns>Todos os Livros</returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Book> GetAll()
        {
            try
            {
                return this.books;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// É preciso que o resultado possa ser ordenado pelo preço.(asc e desc)
        /// </summary>
        /// <param name="Option">Onde 1 significa uma ordenação Ascendente e 2 uma Descendente</param>
        /// <returns>Lista Ordenada</returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("SortAscOrDescByPrice/{Option:int}")]
        public IEnumerable<Book> SortAscOrDescByPrice(int Option)
        {
            if (Option != 1 && Option != 2)
                throw new Exception("Opção Invalida!");
            try
            {
                if (Option == 1)
                {
                    this.books = this.sortList.SortAscByPryce(this.books);
                }
                else
                {
                    this.books = this.sortList.SortDescByPryce(this.books);
                }
                return this.books;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// buscar livros por suas especificações(autor, nome do livro ou outro atributo)
        /// </summary>
        /// <param name="Specifications">Especificação que está buscando</param>
        /// <returns>Retorna uma livro com a especificação que foi pesquisada</returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("GetBookBySpecifications/{Specifications}")]
        public IEnumerable<Book> GetBookBySpecifications(string Specifications)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            try
            {
                return this.bookSpecifications.GetBookBySpecifications(this.books, Specifications);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Disponibilizar um método que calcule o valor do frete em 20% o valor do livro.
        /// </summary>
        /// <param name="idBook">Passar o Id do Livro</param>
        /// <returns>Retorna o Valor do frete daquele livro</returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("GetPriceShipping/{idBook:int}")]
        public double GetPriceShipping(int idBook)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            try
            {
                Book book = this.books.Find(b=>b.Id == idBook);
                return this.priceShipping.CalcPrice(book);
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

    }
}
