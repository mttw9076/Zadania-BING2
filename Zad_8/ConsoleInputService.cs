namespace Zad_8
{
    public class ConsoleInputService
    {
        public decimal GetAmount()
        {
            Console.Write("Podaj kwotę w PLN: ");
            string input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal amount))
                return amount;

            Console.WriteLine("Nieprawidłowa kwota, ustawiam 0.");
            return 0;
        }

        public string GetCurrency()
        {
            Console.Write("Podaj walutę (EUR/USD): ");
            return Console.ReadLine()?.ToUpper() ?? "EUR";
        }
    }

}