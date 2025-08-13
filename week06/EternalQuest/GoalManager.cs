public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private int _level;
        private List<string> _achievements;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
            _level = 1;
            _achievements = new List<string>();
        }

        public void Run()
        {
            LoadData();
            
            bool running = true;
            while (running)
            {
                DisplayHeader();
                DisplayMenu();
                
                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        DisplayGoals();
                        break;
                    case "2":
                        CreateNewGoal();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        DisplayStatistics();
                        break;
                    case "5":
                        SaveData();
                        break;
                    case "6":
                        SaveData();
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
                
                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.WriteLine("-- ETERNAL QUEST --");
            
            Console.ResetColor();
            
            Console.WriteLine($"Score: {_score} points | Level: {_level} | Goals: {_goals.Count}");
            
            if (_achievements.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Recent Achievement: {_achievements.Last()}");
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Show Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Statistics");
            Console.WriteLine("5. Save Progress");
            Console.WriteLine("6. Quit");
            Console.Write("\nSelect a choice from the menu: ");
        }

        private void DisplayGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet! Create some goals to get started on your eternal quest.");
                return;
            }

            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Goal goal = _goals[i];
                Console.WriteLine($"{i + 1}. {goal.GetDisplayStatus()} {goal.GetDetailsString()} [{goal.Category}]");
            }
        }

        private void CreateNewGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("1. Simple Goal (completed once)");
            Console.WriteLine("2. Eternal Goal (never ending)");
            Console.WriteLine("3. Checklist Goal (completed a certain number of times)");
            Console.WriteLine("4. Negative Goal (lose points for bad habits)");
            Console.WriteLine("5. Progress Goal (track progress towards large objective)");
            Console.Write("Which type of goal would you like to create? ");

            string choice = Console.ReadLine();
            
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());
            
            Console.Write("What category is this goal? (Spiritual/Physical/Mental/Social/General): ");
            string category = Console.ReadLine();
            
            Console.Write("What difficulty level? (1=Easy, 2=Medium, 3=Hard): ");
            int difficulty = Math.Max(1, Math.Min(3, int.Parse(Console.ReadLine())));

            Goal newGoal = null;

            switch (choice)
            {
                case "1":
                    newGoal = new SimpleGoal(name, description, points, category, difficulty);
                    break;
                case "2":
                    newGoal = new EternalGoal(name, description, points, category, difficulty);
                    break;
                case "3":
                    Console.Write("How many times must it be accomplished for it to be complete? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());
                    newGoal = new ChecklistGoal(name, description, points, target, bonus, category, difficulty);
                    break;
                case "4":
                    newGoal = new NegativeGoal(name, description, points, category, difficulty);
                    break;
                case "5":
                    Console.Write($"What is the target amount to complete? ");
                    int targetAmount = int.Parse(Console.ReadLine());
                    Console.Write("What is the unit of measurement? (pages, miles, hours, etc.): ");
                    string unit = Console.ReadLine();
                    
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            if (newGoal != null)
            {
                _goals.Add(newGoal);
                Console.WriteLine($"Goal '{name}' created successfully!");
            }
        }

        private void RecordEvent()
        {
            DisplayGoals();
            Console.Write("Which goal did you accomplish? ");
            
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _goals.Count)
            {
                Goal selectedGoal = _goals[choice - 1];
                int pointsEarned = selectedGoal.RecordEvent();
                
                if (pointsEarned != 0)
                {
                    _score += pointsEarned;
                    CheckForLevelUp();
                    CheckForAchievements();
                }
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        private void CheckForLevelUp()
        {
            int newLevel = (_score / 1000) + 1; 
            if (newLevel > _level)
            {
                _level = newLevel;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"LEVEL UP! You are now level {_level}!");
                Console.ResetColor();
                _achievements.Add($"Reached Level {_level}");
            }
        }

        private void CheckForAchievements()
        {
            if (_score >= 5000 && !_achievements.Contains("Score Master"))
            {
                _achievements.Add("Score Master");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Achievement Unlocked: Score Master (5000+ points)!");
                Console.ResetColor();
            }

            if (_goals.Count(g => g.IsComplete()) >= 10 && !_achievements.Contains("Goal Crusher"))
            {
                _achievements.Add("Goal Crusher");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Achievement Unlocked: Goal Crusher (10 completed goals)!");
                Console.ResetColor();
            }

            var eternalGoals = _goals.OfType<EternalGoal>();
            if (eternalGoals.Any(g => g.LongestStreak >= 30) && !_achievements.Contains("Streak Legend"))
            {
                _achievements.Add("Streak Legend");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Achievement Unlocked: Streak Legend (30+ day streak)!");
                Console.ResetColor();
            }
        }

        private void DisplayStatistics()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-- QUEST STATISTICS --");
            Console.ResetColor();
            Console.WriteLine();
            
            Console.WriteLine($"Total Score: {_score} points");
            Console.WriteLine($"Current Level: {_level}");
            Console.WriteLine($"Progress to next level: {_score % 1000}/1000 points");
            Console.WriteLine($"Total Goals: {_goals.Count}");
            Console.WriteLine($"Completed Goals: {_goals.Count(g => g.IsComplete())}");
            Console.WriteLine();

            var categoryStats = _goals.GroupBy(g => g.Category)
            .Select(group => new { Category = group.Key, Count = group.Count() })
            .OrderByDescending(x => x.Count);
            
            Console.WriteLine("Goals by Category:");
            foreach (var stat in categoryStats)
            {
                Console.WriteLine($"   {stat.Category}: {stat.Count} goals");
            }
            Console.WriteLine();

            var eternalGoals = _goals.OfType<EternalGoal>().Where(g => g.CurrentStreak > 0);
            if (eternalGoals.Any())
            {
                Console.WriteLine("Current Streaks:");
                foreach (var goal in eternalGoals.OrderByDescending(g => g.CurrentStreak))
                {
                    Console.WriteLine($"   {goal.Name}: {goal.CurrentStreak} days");
                }
                Console.WriteLine();
            }

            if (_achievements.Count > 0)
            {
                Console.WriteLine("Achievements:");
                foreach (var achievement in _achievements)
                {
                    Console.WriteLine($"{achievement}");
                }
            }
        }

        private void SaveData()
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter("goals.txt"))
                {
                    outputFile.WriteLine($"SCORE:{_score}");
                    outputFile.WriteLine($"LEVEL:{_level}");
                    
                    outputFile.WriteLine($"ACHIEVEMENTS:{string.Join("|", _achievements)}");
                    
                    foreach (Goal goal in _goals)
                    {
                        outputFile.WriteLine(goal.GetStringRepresentation());
                    }
                }
                Console.WriteLine("Progress saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        private void LoadData()
        {
            if (!File.Exists("goals.txt"))
                return;

            try
            {
                string[] lines = File.ReadAllLines("goals.txt");
                
                foreach (string line in lines)
                {
                    if (line.StartsWith("SCORE:"))
                    {
                        _score = int.Parse(line.Substring(6));
                    }
                    else if (line.StartsWith("LEVEL:"))
                    {
                        _level = int.Parse(line.Substring(6));
                    }
                    else if (line.StartsWith("ACHIEVEMENTS:"))
                    {
                        string achievementsData = line.Substring(13);
                        if (!string.IsNullOrEmpty(achievementsData))
                        {
                            _achievements = achievementsData.Split('|').ToList();
                        }
                    }
                    else if (line.Contains(":"))
                    {
                        string[] parts = line.Split(':');
                        string goalType = parts[0];
                        string goalData = parts[1];

                        Goal goal = goalType switch
                        {
                            "SimpleGoal" => SimpleGoal.CreateFromString(goalData),
                            "EternalGoal" => EternalGoal.CreateFromString(goalData),
                            "ChecklistGoal" => ChecklistGoal.CreateFromString(goalData),
                            "NegativeGoal" => NegativeGoal.CreateFromString(goalData),
                            "ProgressGoal" => ProgressGoal.CreateFromString(goalData),
                            _ => null
                        };

                        if (goal != null)
                        {
                            _goals.Add(goal);
                        }
                    }
                }
                Console.WriteLine("Progress loaded successfully!");
                System.Threading.Thread.Sleep(1000); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
