using System;
using Microsoft.Data.Sqlite;

namespace Zad_15
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=users.db";

            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            // Tworzymy tabelę jeśli nie istnieje
            var createTableCmd = connection.CreateCommand();
            createTableCmd.CommandText =
            @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Email TEXT NOT NULL
                );
            ";
            createTableCmd.ExecuteNonQuery();

            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1 - Dodaj użytkownika");
                Console.WriteLine("2 - Wyświetl listę użytkowników");
                Console.WriteLine("0 - Wyjście");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddUser(connection);
                        break;
                    case "2":
                        ShowUsers(connection);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja!");
                        break;
                }
            }
        }

        static void AddUser(SqliteConnection connection)
        {
            Console.Write("Podaj imię: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Podaj email: ");
            string email = Console.ReadLine() ?? string.Empty;

            var insertCmd = connection.CreateCommand();
            insertCmd.CommandText = "INSERT INTO Users (Name, Email) VALUES ($name, $email)";
            insertCmd.Parameters.AddWithValue("$name", name);
            insertCmd.Parameters.AddWithValue("$email", email);

            insertCmd.ExecuteNonQuery();

            Console.WriteLine("✅ Użytkownik dodany!");
        }

        static void ShowUsers(SqliteConnection connection)
        {
            var selectCmd = connection.CreateCommand();
            selectCmd.CommandText = "SELECT Id, Name, Email FROM Users";

            using var reader = selectCmd.ExecuteReader();
            Console.WriteLine("\n=== Lista użytkowników ===");
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}. {reader.GetString(1)} - {reader.GetString(2)}");
            }
        }
    }
}
