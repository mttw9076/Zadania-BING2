using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[]  args)
    {
        Console.WriteLine("Welcome to the game!");
        Console.WriteLine("Pick a number between 1 and 100:");
        int userGuess = int.Parse(Console.ReadLine());
        Random rand = new Random();
        int numberToGuess = rand.Next(1, 101);

        while(userGuess < 1 || userGuess > 100)
        {
            Console.WriteLine("Invalid input. Please pick a number between 1 and 100:");
            userGuess = int.Parse(Console.ReadLine());
        }
        while(userGuess != numberToGuess)
        {
            if(userGuess < numberToGuess)
            {
                Console.WriteLine("Too low! Try again:");
            }
            else
            {
                Console.WriteLine("Too high! Try again:");
            }
            userGuess = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Congratulations! You've guessed the correct number.");
    }
}