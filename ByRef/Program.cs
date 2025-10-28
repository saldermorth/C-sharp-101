
internal class Program
{
    static void Main(string[] args)
    {

        int number = 0;
       
        Console.WriteLine("Före calculateByRef: " + number);
        calulateByRef(ref number);
        Console.WriteLine("Efter calculateByRef: " + number);
    }

    static void calulateByRef(ref int number)
    {
        number = number * 1000;
    }
}

