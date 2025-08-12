public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    protected string _category;
    protected int _difficultyMultiplier;

    protected Goal(string name, string description, int points, string category = "General", int difficulty = 1)
    {
        _name = name;
        _description = description;
        _points = points;
        _category = category;
        _difficultyMultiplier = Math.Max(1, difficulty); 
    }

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int Points { get { return _points; } }
    public string Category { get { return _category; } }
    public int DifficultyMultiplier { get { return _difficultyMultiplier; } }


    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDisplayStatus();
    public abstract string GetStringRepresentation();

    
    public virtual string GetDetailsString()
    {
        return $"{_name} - {_description} ({_points} pts)";
    }
}