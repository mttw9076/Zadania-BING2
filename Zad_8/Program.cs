using System;
using Zad_8;
using System.Threading.Tasks;

namespace Zad_8
{
    class Program
    {
        static async Task Main()
        {
            var inputService = new ConsoleInputService();
            var currencyService = new CurrencyService();

            decimal amountPLN = inputService.GetAmount();
            string currency = inputService.GetCurrency();

            decimal? rate = await currencyService.GetRateAsync(currency);

            if (rate.HasValue)
            {
                decimal converted = currencyService.Convert(amountPLN, rate.Value);
                Console.WriteLine($"{amountPLN} PLN ➡️ {converted:F2} {currency}");
            }
            else
            {
                Console.WriteLine("⚠️ Nie udało się pobrać kursu waluty.");
            }

        }
    }
}
