using System;
public class PromptGenerator
{
    public List<string> entryOptions = new List<string>
            {
                "What did I learn about myself today?",
                "When did I feel most confident this week?",
                "List 3 things you're grateful for today and why.",
                "What small moment brought you joy today?",
                "What is one habit I want to build, and why?",
                "If I weren't afraid, what would I do?",
                "What emotions am I feeling right now? Why?",
                "What do I need to let go of today?",
                "Write a letter from your future self to your present self.",
                "Invent a new tradition and describe how you'd celebrate it.",

            };
    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int randomIndex = rand.Next(entryOptions.Count);
        return entryOptions[randomIndex]; 
    }
}

class Program
{
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");
    }
}