using System;
class Temperture
{
    private double temperature;

    public Temperture(double temperature)
    {
        this.temperature = temperature;
    }

    public double ToFahrenheit()
    {
        return (temperature * 9 / 5) + 32;
    }

    public double ToCelsius()
    {
        return (temperature - 32) * 5 / 9;
    }
}
class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Temperature Conversion:");
        Console.WriteLine("-----------------------");
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        Console.WriteLine();
        Console.WriteLine("Choose an option (1 or 2): ");
        switch(Console.ReadLine())
        {
            case "1":
                Console.Write("Enter temperature in Celsius: ");
                double celsius = Convert.ToDouble(Console.ReadLine());
                Temperture tempC = new Temperture(celsius);
                Console.WriteLine($"{celsius} degrees Celsius is {tempC.ToFahrenheit()} degrees Fahrenheit.");
                break;
            case "2":
                Console.Write("Enter temperature in Fahrenheit: ");
                double fahrenheit = Convert.ToDouble(Console.ReadLine());
                Temperture tempF = new Temperture(fahrenheit);
                Console.WriteLine($"{fahrenheit} degrees Fahrenheit is {tempF.ToCelsius()} degrees Celsius.");
                break;
            default:
                Console.WriteLine("Invalid option selected.");
                break;
        }
    }
}