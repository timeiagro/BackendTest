namespace TestWebAPI.Models
{
    public class PriceShipping
    {
        //20% o valor do livro.
        public double CalcPrice(Book book)
        {
            double percentual = 20.0 / 100.0;
            double valor_final = book.Price + (percentual * book.Price);
            return valor_final;
        }
    }
}
