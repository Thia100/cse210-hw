using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Eternal Quest!");
        Console.WriteLine("Your journey of personal growth begins now...\n");
        System.Threading.Thread.Sleep(1500);
            
        GoalManager questManager = new GoalManager();
        questManager.Run();
            
        Console.WriteLine("\nThank you for using Eternal Quest!");
        Console.WriteLine("Keep working on your goals!");
    }
}