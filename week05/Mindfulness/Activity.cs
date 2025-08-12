    abstract class Activity
    {
        private readonly string _name;
        private readonly string _description;
        private int _durationSeconds;

        protected static readonly Random _random = new Random();

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        protected string Name => _name;
        protected string Description => _description;
        protected int Duration => _durationSeconds;

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($" - {Name} -\n");
            Console.WriteLine($"{Description}\n");

            _durationSeconds = PromptForDuration();

            Console.WriteLine("\nGet ready...");
            ShowSpinner(3); 


            Run();

           
            Console.WriteLine();
            Console.WriteLine("Well done!");
            Console.WriteLine($"You have completed the {Name} for {Duration} seconds.");
            ShowSpinner(3);

            try
            {
                LogCompletion();
            }
            catch
            {}
        }

        protected abstract void Run();
        private int PromptForDuration()
        {
            while (true)
            {
                Console.Write("Enter duration in seconds (e.g. 60): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int seconds) && seconds > 0)
                {
                    return seconds;
                }
                Console.WriteLine("Please enter a valid positive integer for seconds.");
            }
        }

        
        protected void ShowSpinner(int seconds)
        {
            char[] sequence = new char[] { '|', '/', '-', '\\' };
            int idx = 0;
            DateTime end = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < end)
            {
                Console.Write(sequence[idx % sequence.Length]);
                Thread.Sleep(250); 
                Console.Write("\b"); 
                idx++;
            }
            Console.WriteLine();
        }


        protected void ShowCountdown(int seconds)
        {
            for (int s = seconds; s >= 1; s--)
            {
                Console.Write(s);
                Thread.Sleep(1000);
                Console.Write("\r" + new string(' ', 10) + "\r");
            }
        }

        protected virtual void LogCompletion()
        {
            string logLine = $"{DateTime.Now:u} | {Name} | {Duration} seconds\n";
            File.AppendAllText("mindfulness_log.txt", logLine);
        }

        protected string ReadLineWithTimeout(TimeSpan timeout)
        {
            Task<string> task = Task.Run(() => Console.ReadLine());
            bool completed = task.Wait(timeout);
            if (completed) return task.Result;
            return null;
        }
    }