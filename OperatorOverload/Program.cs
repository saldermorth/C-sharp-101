using System;

public class Complex

{
    public double Real { get; }
    public double Imaginary { get; }

    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    // Operator overloading för addition (+)
    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    // Operator overloading för subtraktion (-)
    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }

    // Operator overloading för multiplikation (*)
    public static Complex operator *(Complex a, Complex b)
    {
        double real = a.Real * b.Real - a.Imaginary * b.Imaginary;
        double imaginary = a.Real * b.Imaginary + a.Imaginary * b.Real;
        return new Complex(real, imaginary);
    }

    // Operator overloading för jämförelse (==)
    public static bool operator ==(Complex a, Complex b)
    {
        // Null-check
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Real == b.Real && a.Imaginary == b.Imaginary;
    }

    // Om vi överlagrar ==, måste vi också överlagra !=
    public static bool operator !=(Complex a, Complex b)
    {
        return !(a == b);
    }

    // Överstyra Equals för konsekvens med ==
    public override bool Equals(object obj)
    {
        if (obj is Complex other)
            return this == other;
        return false;
    }

    // Överstyra GetHashCode för konsekvens med Equals
    public override int GetHashCode()
    {
        return Real.GetHashCode() ^ (Imaginary.GetHashCode() * 17);
    }

    // Sträng-representation
    public override string ToString()
    {
        if (Imaginary == 0)
            return Real.ToString();

        if (Real == 0)
            return Imaginary + "i";

        if (Imaginary < 0)
            return $"{Real} - {Math.Abs(Imaginary)}i";

        return $"{Real} + {Imaginary}i";
    }
}

// Användning av Complex-klassen med överlagrade operatorer
class Program
{

    

    static void Main()
    {

        // Exempel på existerande operator overload av -
        DateTime future= new DateTime(2026, 02, 14);
        DateTime now = new DateTime(2025, 02, 14);

        //                 egen  - funktionalitet
        TimeSpan result = future - now;
        Console.WriteLine(result);


        // Exempel på egenbygd operator overload
        Car bmw = new Car( 320, "550I");
        Car audi = new Car( 318, "S6");

        Car fastestCar = bmw > audi;
        Console.WriteLine(fastestCar.Name);

        Complex a = new Complex(3, 2);  // 3 + 2i
        Complex b = new Complex(1, 4);  // 1 + 4i

        // Använd överlagrade operatorer
        Complex sum = a + b;
        Complex difference = a - b;
        Complex product = a * b;

        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}");
        Console.WriteLine($"a + b = {sum}");
        Console.WriteLine($"a - b = {difference}");
        Console.WriteLine($"a * b = {product}");

        // Jämförelse med överlagrade operatorer
        Complex c = new Complex(3, 2);  // Samma som a
        Console.WriteLine($"a == c: {a == c}");  // True
        Console.WriteLine($"a == b: {a == b}");  // False
    }

    public class Car
    {
        public int TopSpeed { get; set; }
        public string Name { get; set; }

        public Car(int topSpeed, string name)
        {
            TopSpeed = topSpeed;
            Name = name;
        }
        public Car()
        {

        }

        public static Car operator >(Car left ,Car right)
        {

            Car iHaveGotTheFastestCar = new();

            if (left.TopSpeed > right.TopSpeed)
            {
                iHaveGotTheFastestCar = left;
            }
            else 
            {
                iHaveGotTheFastestCar = right;
            }
            return iHaveGotTheFastestCar;
        }
          public static Car operator <(Car left, Car right)
        {

            Car iHaveGotTheSlowestCar = new();

            if (left.TopSpeed > right.TopSpeed)
            {
                iHaveGotTheSlowestCar = left;
            }
            else 
            {
                iHaveGotTheSlowestCar = right;
            }
            return iHaveGotTheSlowestCar;
        }


    }
}