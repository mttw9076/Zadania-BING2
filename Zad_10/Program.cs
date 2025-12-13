using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Zad_10
{
    class Program
    {
        static void Main()
        {
            string filePath = "tekst.txt"; // plik z tekstem

            if (!File.Exists(filePath))
            {
                Console.WriteLine("❌ Plik nie istnieje!");
                return;
            }

            string text = File.ReadAllText(filePath);

            // Liczenie słów
            var words = Regex.Matches(text.ToLower(), @"\w+")
                             .Cast<Match>()
                             .Select(m => m.Value)
                             .ToList();

            int wordCount = words.Count;

            // Liczenie zdań (proste rozdzielenie po ., !, ?)
            var sentences = Regex.Split(text, @"[.!?]+")
                                 .Where(s => !string.IsNullOrWhiteSpace(s))
                                 .ToList();

            int sentenceCount = sentences.Count;

            // Najczęściej występujące słowo
            var mostCommonWord = words.GroupBy(w => w)
                                      .OrderByDescending(g => g.Count())
                                      .First().Key;

            Console.WriteLine($"📊 Liczba słów: {wordCount}");
            Console.WriteLine($"📊 Liczba zdań: {sentenceCount}");
            Console.WriteLine($"🏆 Najczęściej występujące słowo: {mostCommonWord}");
        }
    }
}
