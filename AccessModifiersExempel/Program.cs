namespace AccessModifiersExempel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public decimal GetPriceWithVat(decimal vatRate)
        {
            return Price * (1 + vatRate);
        }
    }

    public abstract class Payment
    {
        public decimal Amount { get; set; }
        public abstract void Process();
    }

    public class CreditCardPayment : Payment
    {
        public string CardNumber { get; set; }
        public override void Process()
        {
            Console.WriteLine("Processing credit card payment...");
        }
    }

    public class SwishPayment : Payment
    {
        public string PhoneNumber { get; set; }
        public override void Process()
        {
            Console.WriteLine("Processing Swish payment...");
        }
    }


    public interface IProductRepository
    {
        Product GetById(int id);
        void Save(Product product);
    }

    public class SqlProductRepository : IProductRepository
    {
        public Product GetById(int id) => new Product();
        public void Save(Product product) { }
    }




}
