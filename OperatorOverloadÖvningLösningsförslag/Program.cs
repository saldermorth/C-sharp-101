using System;

namespace FractionDemo
{
    // TIPS FÖR MATEMATISKA OPERATIONER MED BRÅKTAL

    // 1. ADDITION AV BRÅK:
    // (a/b) + (c/d) = (a*d + c*b)/(b*d)
    // Exempel: 1/4 + 2/3 = (1*3 + 2*4)/(4*3) = (3 + 8)/12 = 11/12

    // 2. SUBTRAKTION AV BRÅK:
    // (a/b) - (c/d) = (a*d - c*b)/(b*d)
    // Exempel: 3/4 - 1/3 = (3*3 - 1*4)/(4*3) = (9 - 4)/12 = 5/12

    // 3. MULTIPLIKATION AV BRÅK:
    // (a/b) * (c/d) = (a*c)/(b*d)
    // Exempel: 2/3 * 3/5 = (2*3)/(3*5) = 6/15 = 2/5

    // 4. DIVISION AV BRÅK:
    // (a/b) / (c/d) = (a/b) * (d/c) = (a*d)/(b*c)
    // Exempel: 2/3 / 4/5 = 2/3 * 5/4 = (2*5)/(3*4) = 10/12 = 5/6

    // 5. FÖRENKLING AV BRÅK:
    // a/b kan förenklas genom att dividera täljare och nämnare med deras största gemensamma delare (GCD)
    // a/b = (a/GCD)/(b/GCD)
    // Exempel: 8/12, GCD(8,12) = 4, så 8/12 = (8/4)/(12/4) = 2/3

    // 6. STÖRSTA GEMENSAMMA DELARE (GCD) MED EUKLIDES ALGORITM:
    // GCD(a,b) beräknas rekursivt enligt:
    // GCD(a,b) = GCD(b, a mod b) tills b blir 0, då är GCD(a,0) = a
    // Exempel: GCD(48,18) = GCD(18,12) = GCD(12,6) = GCD(6,0) = 6

    // 7. JÄMFÖRELSE AV BRÅK:
    // Om två bråk a/b och c/d är förenklade, är de lika om a=c och b=d
    // Alternativt: (a/b) = (c/d) om a*d = b*c
    public class Fraction
    {
        public int Numerator { get; private set; }      // Täljare
        public int Denominator { get; private set; }    // Nämnare

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Nämnaren kan inte vara noll.");

            // Förenkla bråket
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));

            // Hantera tecken
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        // Beräkna största gemensamma delaren med Euklides algoritm
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Addition (+)
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(
                a.Numerator * b.Denominator + b.Numerator * a.Denominator,
                a.Denominator * b.Denominator);
        }

        // Subtraktion (-)
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(
                a.Numerator * b.Denominator - b.Numerator * a.Denominator,
                a.Denominator * b.Denominator);
        }

        // Multiplikation (*)
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(
                a.Numerator * b.Numerator,
                a.Denominator * b.Denominator);
        }

        // Division (/)
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException();

            return new Fraction(
                a.Numerator * b.Denominator,
                a.Denominator * b.Numerator);
        }

        // Lika med (==)
        public static bool operator ==(Fraction a, Fraction b)
        {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);

            if (ReferenceEquals(b, null))
                return false;

            return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
        }

        // Inte lika med (!=)
        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        // Överskugga Equals och GetHashCode
        public override bool Equals(object obj)
        {
            return obj is Fraction other && this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        public override string ToString()
        {
            return Denominator == 1 ? $"{Numerator}" : $"{Numerator}/{Denominator}";
        }
    }
}