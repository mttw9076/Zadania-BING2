using System;
using System.Collections.Generic;

namespace ToDoApp
{
    class Program
    {
        static List<TaskItem> tasks = new();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                ShowTasks();

                Console.WriteLine("\nWybierz opcję:");
                Console.WriteLine("1 - Dodaj zadanie");
                Console.WriteLine("2 - Oznacz jako wykonane");
                Console.WriteLine("3 - Usuń zadanie");
                Console.WriteLine("0 - Wyjście");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        MarkAsDone();
                        break;
                    case "3":
                        DeleteTask();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ShowTasks()
        {
            Console.WriteLine("=== Lista zadań ===");
            if (tasks.Count == 0)
            {
                Console.WriteLine("Brak zadań.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];
                string status = task.IsDone ? "[✔]" : "[ ]";
                Console.WriteLine($"{i + 1}. {status} {task.Title}");
            }
        }

        static void AddTask()
        {
            Console.Write("Podaj nazwę zadania: ");
            string title = Console.ReadLine() ?? string.Empty;
            tasks.Add(new TaskItem { Title = title });
        }

        static void MarkAsDone()
        {
            Console.Write("Podaj numer zadania do oznaczenia: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                tasks[index - 1].IsDone = true;
            }
        }

        static void DeleteTask()
        {
            Console.Write("Podaj numer zadania do usunięcia: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                tasks.RemoveAt(index - 1);
            }
        }
    }

    class TaskItem
    {
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
    }
}
