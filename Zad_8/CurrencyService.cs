using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zad_8
{
    public class CurrencyService
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<decimal?> GetRateAsync(string currencyCode)
        {
            try
            {
                string url = $"https://api.nbp.pl/api/exchangerates/rates/a/{currencyCode}/?format=json";
                string response = await _client.GetStringAsync(url);

                using var doc = JsonDocument.Parse(response);
                return doc.RootElement
                          .GetProperty("rates")[0]
                          .GetProperty("mid")
                          .GetDecimal();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"❌ Błąd sieci: {ex.Message}");
                return null;
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("❌ Nie znaleziono kursu dla podanej waluty.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Nieoczekiwany błąd: {ex.Message}");
                return null;
            }
        }
        public decimal Convert(decimal amountPLN, decimal rate)
        {
            return amountPLN / rate;
        }
    }
}
