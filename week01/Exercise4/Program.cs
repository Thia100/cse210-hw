using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int input;
        int total = 0;


        while (true)
        {
            Console.Write("Enter a number (0 to stop): ");
            input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                break;
            }
            numbers.Add(input);
        }


        foreach (int number in numbers)
        {
            total += number;
        }
        Console.WriteLine($"The sum is : {total}");

        int average = total / numbers.Count;
        Console.WriteLine($"The average is : {average}");

        int max = numbers.Max();
        Console.WriteLine($"The largest number is : {max}");

        

















    }
}