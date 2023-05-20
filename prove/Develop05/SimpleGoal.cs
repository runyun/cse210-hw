public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int point, bool isComplete = false) : base(name, description, point)
    {
        _isComplete = isComplete;
    }

    public override string GetSummary()
    {
        return $"{GetName()} ({GetDescription()})";
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string ConvertObjectToString()
    {
        return $"SimpleGoal|{GetName()}|{GetDescription()}|{GetPoint()}|{_isComplete.ToString().ToUpper()}";
    }


    public override int RecordEvent()
    {
        _isComplete = true;
        return GetPoint();
    }
}