using System;


class Calculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return a / b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
                    Calculator calculator = new Calculator();

        Console.WriteLine("Simple Calculator Operations:");
        Console.WriteLine("------------------------------");
        Console.WriteLine("Enter two numbers:");
        double num1 = Convert.ToDouble(Console.ReadLine());
        double num2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("------------------------------");
        Console.WriteLine("Choose operation: +, -, *, /, or 'exit' to quit");
        string operation = Console.ReadLine();
        switch(operation)
        {
            case "+":
                Console.WriteLine($"Result: {calculator.Add(num1, num2)}");
                break;
            case "-":
                Console.WriteLine($"Result: {calculator.Subtract(num1, num2)}");
                break;
            case "*":
                Console.WriteLine($"Result: {calculator.Multiply(num1, num2)}");
                break;
            case "/":
                try
                {
                    Console.WriteLine($"Result: {calculator.Divide(num1, num2)}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case "exit":
                return;
            default:
                Console.WriteLine("Invalid operation.");
                break;
    }
    }
}
}