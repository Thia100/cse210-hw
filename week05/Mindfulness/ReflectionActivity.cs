class ReflectionActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private readonly List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private Queue<string> _promptQueue;
        private Queue<string> _questionQueue;

        public ReflectionActivity()
            : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
            ResetPromptQueue();
            ResetQuestionQueue();
        }

        private void ResetPromptQueue()
        {
            var shuffled = _prompts.OrderBy(x => _random.Next()).ToList();
            _promptQueue = new Queue<string>(shuffled);
        }

        private void ResetQuestionQueue()
        {
            var shuffled = _questions.OrderBy(x => _random.Next()).ToList();
            _questionQueue = new Queue<string>(shuffled);
        }

        protected override void Run()
        {
            if (_promptQueue.Count == 0) ResetPromptQueue();
            string prompt = _promptQueue.Dequeue();

            Console.WriteLine("--- Reflection Prompt ---");
            Console.WriteLine(prompt);
            Console.WriteLine("\nWhen you have something in mind, press Enter to begin.");
            Console.ReadLine();

            DateTime end = DateTime.Now.AddSeconds(Duration);

            while (DateTime.Now < end)
            {
                if (_questionQueue.Count == 0) ResetQuestionQueue();
                string question = _questionQueue.Dequeue();
                Console.WriteLine();
                Console.WriteLine($"> {question}");

                
                int pauseSeconds = Math.Min(5, Math.Max(1, (int)(end - DateTime.Now).TotalSeconds));
                ShowSpinner(pauseSeconds);
            }
        }
    }