using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Input your grade percentage (0-100): ");
        string input = Console.ReadLine();
        int percentage;

        if (int.TryParse(input, out percentage))
        {
            string letter;
            if (percentage >= 90)
            {
                letter = "A";
            }
            else if (percentage >= 80)
            {
                letter = "B";
            }
            else if (percentage >= 70)
            {
                letter = "C";
            }
            else if (percentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            Console.WriteLine($"Your letter grade is {letter}.");
            if (percentage >= 70)
            {
                Console.WriteLine("Congratulations, you passed!");
            }
            else
            {
                Console.WriteLine("Sorry, you did not pass. But keep pushing, you'll get there!");
            }

        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
        }   
        

        
        
    }
}