using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, string> contacts = new Dictionary<string, string>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View Contacts");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ViewContacts();
                    break;
                case "3":
                    DeleteContact();
                    break;
                case "4":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    static void AddContact()
    {
        Console.Write("Enter contact name: ");
        string name = Console.ReadLine();
        Console.Write("Enter contact phone number: ");
        string phoneNumber = Console.ReadLine();

        if (!contacts.ContainsKey(name))
        {
            contacts[name] = phoneNumber;
            Console.WriteLine("Contact added successfully.");
        }
        else
        {
            Console.WriteLine("Contact already exists.");
        }
    }
    static void ViewContacts()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts available.");
            return;
        }

        Console.WriteLine("Contacts:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Name: {contact.Key}, Phone Number: {contact.Value}");
        }
    }
    static void DeleteContact()
    {
        Console.Write("Enter contact name to delete: ");
        string name = Console.ReadLine();

        if (contacts.Remove(name))
        {
            Console.WriteLine("Contact deleted successfully.");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }
}