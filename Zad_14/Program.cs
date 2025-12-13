using System;

namespace Zad_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbę:");

            try
            {
                string? input = Console.ReadLine();
                int number = int.Parse(input ?? "0");

                Console.WriteLine($"Wpisałeś liczbę: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Błąd: Wpisany tekst nie jest liczbą!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Błąd: Podana liczba jest zbyt duża lub zbyt mała!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nieoczekiwany błąd: {ex.Message}");
            }

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}
