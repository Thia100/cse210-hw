public class EternalGoal : Goal
    {
        private int _timesCompleted;
        private int _currentStreak;
        private int _longestStreak;
        private DateTime _lastCompleted;

        public EternalGoal(string name, string description, int points, string category = "General", int difficulty = 1) 
            : base(name, description, points, category, difficulty)
        {
            _timesCompleted = 0;
            _currentStreak = 0;
            _longestStreak = 0;
            _lastCompleted = DateTime.MinValue;
        }

        public int TimesCompleted { get { return _timesCompleted; } }
        public int CurrentStreak { get { return _currentStreak; } }
        public int LongestStreak { get { return _longestStreak; } }

        public override int RecordEvent()
        {
            _timesCompleted++;
            
            
            if (_lastCompleted.Date == DateTime.Today.AddDays(-1))
            {
                _currentStreak++; 
            }
            else if (_lastCompleted.Date != DateTime.Today)
            {
                _currentStreak = 1; 
            }
            
            _longestStreak = Math.Max(_longestStreak, _currentStreak);
            _lastCompleted = DateTime.Today;

            int basePoints = Points * DifficultyMultiplier;
            int streakBonus = _currentStreak >= 7 ? (int)(basePoints * 0.5) : 0; 
            int totalPoints = basePoints + streakBonus;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"You earned {basePoints} points!");
            if (streakBonus > 0)
            {
                Console.WriteLine($"Streak bonus: {streakBonus} points! ({_currentStreak} day streak)");
            }
            Console.ResetColor();

            return totalPoints;
        }

        public override bool IsComplete()
        {
            return false; 
        }

        public override string GetDisplayStatus()
        {
            string streakText = _currentStreak > 0 ? $"{_currentStreak}" : "";
            return $"[∞] Completed {_timesCompleted} times{streakText}";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{Name},{Description},{Points},{Category},{DifficultyMultiplier},{_timesCompleted},{_currentStreak},{_longestStreak},{_lastCompleted:yyyy-MM-dd}";
        }

        public static EternalGoal CreateFromString(string data)
        {
            string[] parts = data.Split(',');
            var goal = new EternalGoal(parts[0], parts[1], int.Parse(parts[2]), parts[3], int.Parse(parts[4]));
            goal._timesCompleted = int.Parse(parts[5]);
            goal._currentStreak = int.Parse(parts[6]);
            goal._longestStreak = int.Parse(parts[7]);
            goal._lastCompleted = DateTime.Parse(parts[8]);
            return goal;
        }
    }