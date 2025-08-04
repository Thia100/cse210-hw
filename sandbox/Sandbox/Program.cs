using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished: ");
        List<int> numbers = new List<int>();


        while (true)
        {
            Console.Write("Enter a number (0 to stop): ");
            string input = Console.ReadLine();
            int number;

            if (int.TryParse(input, out number))
            {
                if (number == 0)
                {
                    break; 
                }

                numbers.Add(number); // Add valid number to the list
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }








        // Console.Write("Enter a list of numbers, type 0 when finished: ");
        // List<int> numbers = new List<int>();
        // string input = Console.ReadLine();

        // int number;
        // if (int.TryParse(input, out number))
        // {
        //     while (number != 0)
        //     {
        //         Console.WriteLine("Enter a number: ");
        //         numbers.Add(number);




        //     }




        // }
        // else
        // {
        //     Console.WriteLine("Invalid number.");
        // }













    }


    



    
}