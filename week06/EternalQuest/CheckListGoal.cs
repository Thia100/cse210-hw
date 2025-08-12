 public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonusPoints;
        private bool _isComplete;

        public ChecklistGoal(string name, string description, int points, int target, int bonusPoints, string category = "General", int difficulty = 1) 
            : base(name, description, points, category, difficulty)
        {
            _amountCompleted = 0;
            _target = target;
            _bonusPoints = bonusPoints;
            _isComplete = false;
        }

        public int AmountCompleted { get { return _amountCompleted; } }
        public int Target { get { return _target; } }

        public override int RecordEvent()
        {
            if (_isComplete)
            {
                Console.WriteLine("This goal is already complete!");
                return 0;
            }

            _amountCompleted++;
            int earnedPoints = Points * DifficultyMultiplier;

            if (_amountCompleted >= _target)
            {
                _isComplete = true;
                int bonusPoints = _bonusPoints * DifficultyMultiplier;
                earnedPoints += bonusPoints;
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"CHECKLIST COMPLETE! You earned {Points * DifficultyMultiplier} points plus {bonusPoints} bonus points!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Progress made! You earned {earnedPoints} points! ({_amountCompleted}/{_target})");
                Console.ResetColor();
            }

            return earnedPoints;
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetDisplayStatus()
        {
            if (_isComplete)
                return "[X]";
            else
                return $"[ ] Completed {_amountCompleted}/{_target} times";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{Name},{Description},{Points},{Category},{DifficultyMultiplier},{_target},{_bonusPoints},{_amountCompleted},{_isComplete}";
        }

        public static ChecklistGoal CreateFromString(string data)
        {
            string[] parts = data.Split(',');
            var goal = new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[5]), int.Parse(parts[6]), parts[3], int.Parse(parts[4]));
            goal._amountCompleted = int.Parse(parts[7]);
            goal._isComplete = bool.Parse(parts[8]);
            return goal;
        }
    }