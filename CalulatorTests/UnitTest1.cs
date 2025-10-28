namespace CalulatorTests
{
    public class UnitTest1
    {
        [Fact]
        public void Add_ShouldReturnSumOfNumbers()
        {
            var calc = new Calculator();

            var result = calc.Add(1, 2, 3);

            Assert.Equal(6, result);
        }
    }
}
/*﻿namespace LearnTest
{
    public class Calculator
    {
        public int Add(int a, int b, int c) => a + b + c;

        public int Multiply(int a, int b) => a * b;

        public bool IsEven(int number) => number % 2 == 0;

        public string Greet(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Hello, stranger";

            return $"Hello, {name}";
        }

        public int Max(int a, int b) => a > b ? a : b;
    }
}

Lägg till Xunit projekt


    public class CalculatorTests
    {
        // TODO 1: Test Add() – should return correct sum of 3 numbers
        // TODO 2: Test Multiply() – should return correct product
        // TODO 3: Test IsEven() – true for even, false for odd numbers
        // TODO 4: Test Greet() – "Hello, Anna" and "Hello, stranger" for empty input
        // TODO 5: Test Max() – should return the highest number

        // Example to get them started:

        [Fact]
        public void Add_ShouldReturnSumOfNumbers()
        {
            var calc = new Calculator();

            var result = calc.Add(1, 2, 3);

            Assert.Equal(6, result);
        }
    }
    }

*/