public class NegativeGoal : Goal
    {
        private int _timesRecorded;

        public NegativeGoal(string name, string description, int pointsLost, string category = "Bad Habits", int difficulty = 1) 
            : base(name, description, pointsLost, category, difficulty)
        {
            _timesRecorded = 0;
        }

        public override int RecordEvent()
        {
            _timesRecorded++;
            int pointsLost = -(Points * DifficultyMultiplier); 
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You lost {Math.Abs(pointsLost)} points for: {Name}");
            Console.ResetColor();
            
            return pointsLost;
        }

        public override bool IsComplete()
        {
            return false; 
        }

        public override string GetDisplayStatus()
        {
            return $"[!] Recorded {_timesRecorded} times";
        }

        public override string GetStringRepresentation()
        {
            return $"NegativeGoal:{Name},{Description},{Points},{Category},{DifficultyMultiplier},{_timesRecorded}";
        }

        public static NegativeGoal CreateFromString(string data)
        {
            string[] parts = data.Split(',');
            var goal = new NegativeGoal(parts[0], parts[1], int.Parse(parts[2]), parts[3], int.Parse(parts[4]));
            goal._timesRecorded = int.Parse(parts[5]);
            return goal;
        }
    }