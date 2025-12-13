using System;
using System.Threading;

namespace Zad_9
{
    class Program
    {
        static void Main()
        {
            Console.Write("Ustaw alarm (HH:mm, np. 11:45): ");
            string alarmInput = Console.ReadLine();

            DateTime? alarmTime = null;
            if (DateTime.TryParse(alarmInput, out DateTime parsedAlarm))
            {
                alarmTime = parsedAlarm;
                Console.WriteLine($"🔔 Alarm ustawiony na {alarmTime:HH:mm}");
            }
            else
            {
                Console.WriteLine("⚠️ Nie ustawiono alarmu.");
            }

            while (true)
            {
                Console.Clear();
                DateTime now = DateTime.Now;
                Console.WriteLine($"🕒 Aktualny czas: {now:HH:mm:ss}");

                if (alarmTime.HasValue && now.Hour == alarmTime.Value.Hour && now.Minute == alarmTime.Value.Minute)
                {
                    Console.WriteLine("🚨 ALARM! 🚨");
                    Console.Beep(); // prosty sygnał dźwiękowy
                    alarmTime = null; // wyłączenie alarmu po uruchomieniu
                }

                Thread.Sleep(1000); // odświeżanie co sekundę
            }
        }
    }
}
