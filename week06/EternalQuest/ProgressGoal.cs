public class ProgressGoal : Goal
    {
        private int _currentProgress;
        private int _targetAmount;
        private string _unit;
        private bool _isComplete;

        public ProgressGoal(string name, string description, int pointsPerUnit, int targetAmount, string unit, string category = "General", int difficulty = 1) 
            : base(name, description, pointsPerUnit, category, difficulty)
        {
            _currentProgress = 0;
            _targetAmount = targetAmount;
            _unit = unit;
            _isComplete = false;
        }

        public override int RecordEvent()
        {
            Console.Write($"How many {_unit} did you complete? ");
            if (int.TryParse(Console.ReadLine(), out int amount) && amount > 0)
            {
                _currentProgress += amount;
                int earnedPoints = (Points * amount) * DifficultyMultiplier;

                if (_currentProgress >= _targetAmount && !_isComplete)
                {
                    _isComplete = true;
                    int bonusPoints = _targetAmount * DifficultyMultiplier;
                    earnedPoints += bonusPoints;
                    
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"GOAL ACHIEVED! You earned {earnedPoints} points (including {bonusPoints} completion bonus)!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"mProgress made! You earned {earnedPoints} points!");
                    Console.ResetColor();
                }

                return earnedPoints;
            }
            return 0;
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetDisplayStatus()
        {
            double percentage = Math.Min(100, (_currentProgress * 100.0) / _targetAmount);
            if (_isComplete)
                return $"[X] Complete! ({_currentProgress}/{_targetAmount} {_unit})";
            else
                return $"[ ] {percentage:F1}% ({_currentProgress}/{_targetAmount} {_unit})";
        }

        public override string GetStringRepresentation()
        {
            return $"ProgressGoal:{Name},{Description},{Points},{Category},{DifficultyMultiplier},{_targetAmount},{_unit},{_currentProgress},{_isComplete}";
        }

        public static ProgressGoal CreateFromString(string data)
        {
            string[] parts = data.Split(',');
            var goal = new ProgressGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[5]), parts[6], parts[3], int.Parse(parts[4]));
            goal._currentProgress = int.Parse(parts[7]);
            goal._isComplete = bool.Parse(parts[8]);
            return goal;
        }
    }