
internal class Program
{
    static void Main(string[] args)
    {

        int number = 99;
        Console.WriteLine("Före calculate: " + number);
        calulate(number);
        Console.WriteLine("Efter calculate: " + number);


        Console.WriteLine("Före calculateByRef: " + number);
        calulateByRef(ref number);
        Console.WriteLine("Efter calculateByRef: " + number);
    }

    static void calulate(int number)
    {
        number = number * 1000;
    }
    static void calulateByRef(ref int number)
    {
        number = number * 1000;
    }
}

