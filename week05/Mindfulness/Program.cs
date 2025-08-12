using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Mindfulness Program";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program\n");
                Console.WriteLine("Please select an activity:");
                Console.WriteLine("1) Breathing Activity");
                Console.WriteLine("2) Reflection Activity");
                Console.WriteLine("3) Listing Activity");
                Console.WriteLine("4) Quit");
                Console.Write("Enter choice (1-4): ");

                string choice = Console.ReadLine();
                Activity activity = null;

                switch (choice)
                {
                    case "1": activity = new BreathingActivity(); break;
                    case "2": activity = new ReflectionActivity(); break;
                    case "3": activity = new ListingActivity(); break;
                    case "4": Console.WriteLine("Goodbye! Take care and be mindful."); return;
                    default:
                        Console.WriteLine("Invalid selection. Press Enter to try again.");
                        Console.ReadLine();
                        continue;
                }

                activity.Start();

                Console.WriteLine("\nPress Enter to return to the main menu.");
                Console.ReadLine();
            }
    }
}
    
