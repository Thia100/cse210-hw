class BreathingActivity : Activity
    {
        private readonly int _inhaleSeconds = 4;
        private readonly int _exhaleSeconds = 6;

        public BreathingActivity()
            : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        protected override void Run()
        {
            DateTime end = DateTime.Now.AddSeconds(Duration);

            while (DateTime.Now < end)
            {
                Console.WriteLine("Breathe in... ");
                int inhale = Math.Min(_inhaleSeconds, (int)(end - DateTime.Now).TotalSeconds);
                if (inhale <= 0) break;
                ShowCountdown(inhale);

                Console.WriteLine();

                Console.WriteLine("Breathe out... ");
                int exhale = Math.Min(_exhaleSeconds, (int)(end - DateTime.Now).TotalSeconds);
                if (exhale <= 0) break;
                ShowCountdown(exhale);
            }
        }
    }