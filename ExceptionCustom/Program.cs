using System;

using System.IO;

using static ExceptionDemo;


class ExceptionDemo

{

    static void Main()
    {
        try
        {

            throw new OrderNotFoundException(42);
        }

        catch (OrderNotFoundException ex)
        {

            Console.WriteLine($"Error: {ex.Message}. Order ID: {ex.OrderId}");
        }

    }

    public class OrderNotFoundException : Exception
    {
        public int OrderId { get; }


        public OrderNotFoundException(int orderId) : base($"Order with ID {orderId} was not found.")
        {
            OrderId = orderId;
        }

        public OrderNotFoundException(int orderId, Exception innerException)

            : base($"Order with ID {orderId} was not found.", innerException)

        {

            OrderId = orderId;

        }

    }

}