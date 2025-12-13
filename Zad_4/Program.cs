using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Password:");
        string password = Console.ReadLine();
        if(PasswordValidation(password))
        {
            Console.WriteLine("Correct password. Access granted.");
        }
        else
        {
            Console.WriteLine("Incorrect password. Access denied.");
        }
    }
    static bool PasswordValidation(string password)
    {
        bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;
        foreach(char c in password)
        {
            if(char.IsUpper(c))
                hasUpper = true;
            else if(char.IsLower(c))
                hasLower = true;
            else if(char.IsDigit(c))
                hasDigit = true;
            else if(!char.IsLetterOrDigit(c))
                hasSpecial = true;
        }
        return hasUpper && hasLower && hasDigit && hasSpecial;
    }
}

