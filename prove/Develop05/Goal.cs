public abstract class Goal
{
    private string _name, _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public int GetPoint()
    {
        return _points;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public abstract string GetSummary();

    public abstract bool IsComplete();
    
    public abstract string ConvertObjectToString();

    public abstract int RecordEvent();
}