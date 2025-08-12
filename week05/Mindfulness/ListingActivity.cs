class ListingActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
            : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        protected override void Run()
        {
            string prompt = _prompts[_random.Next(_prompts.Count)];
            Console.WriteLine("--- Listing Prompt ---");
            Console.WriteLine(prompt);

            Console.WriteLine("\nYou may begin in:");
            ShowCountdown(5);

            List<string> items = new List<string>();
            DateTime end = DateTime.Now.AddSeconds(Duration);

            while (DateTime.Now < end)
            {
                TimeSpan timeLeft = end - DateTime.Now;
                Console.Write("> ");

                string entry = ReadLineWithTimeout(timeLeft);
                if (entry == null)
                {
                    break;
                }

                entry = entry.Trim();
                if (!string.IsNullOrWhiteSpace(entry))
                {
                    items.Add(entry);
                }
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} items. Here they are:");
            foreach (var it in items)
            {
                Console.WriteLine($" - {it}");
            }

    
            try
            {
                File.AppendAllText("mindfulness_log.txt", $"{DateTime.Now:u} | Listing | {Duration} seconds | Items: {items.Count}\n");
            }
            catch { }
        }
    }