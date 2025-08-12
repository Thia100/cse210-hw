public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points, string category = "General", int difficulty = 1) 
            : base(name, description, points, category, difficulty)
        {
            _isComplete = false;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                int earnedPoints = Points * DifficultyMultiplier;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Goal completed! You earned {earnedPoints} points!");
                Console.ResetColor();
                return earnedPoints;
            }
            else
            {
                Console.WriteLine("This goal is already complete!");
                return 0;
            }
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetDisplayStatus()
        {
            return _isComplete ? "[X]" : "[ ]";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{Name},{Description},{Points},{Category},{DifficultyMultiplier},{_isComplete}";
        }

       
        public static SimpleGoal CreateFromString(string data)
        {
            string[] parts = data.Split(',');
            var goal = new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]), parts[3], int.Parse(parts[4]));
            goal._isComplete = bool.Parse(parts[5]);
            return goal;
        }
    }