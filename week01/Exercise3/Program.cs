using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // Generates a number between 1 and 100
        

        Console.Write("What is your guess: ");
        string input2 = Console.ReadLine();
        int guessedNumber = int.Parse(input2);


        while (guessedNumber != magicNumber)
        {
            if (guessedNumber == magicNumber)
            {
                Console.WriteLine("Congratulations! You guessed the magic number!");
            }
            else if (guessedNumber < magicNumber)
            {
                Console.WriteLine("Higher!");
            }
            else
            {
                Console.WriteLine("Lower!");
            }
            Console.Write("Try again: ");
            input2 = Console.ReadLine();
            guessedNumber = int.Parse(input2);
        }
        Console.WriteLine("Congratulations! You guessed the magic number!");
       
        
       
    }
}