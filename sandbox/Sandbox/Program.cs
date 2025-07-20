using System;
using System.IO; 

class Program
{
    static void Main(string[] args)
    {
        // DateTime theCurrentTime = DateTime.Now;
        // string dateText = theCurrentTime.ToShortDateString();
        // Console.WriteLine($"{dateText}");

        string filename = "C:\\Users\\user\\OneDrive\\Desktop\\cse210-projects\\cse210-hw\\sandbox\\journal.txt";
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("This will be the first line in the file.");
            string color = "Blue";
            outputFile.WriteLine($"My favorite color is {color}");
            outputFile.WriteLine($"My favorite color is {color}");
        }

        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(":");
            string favcolor = parts[0];
            Console.WriteLine(favcolor);

        }

    }


    



    
}