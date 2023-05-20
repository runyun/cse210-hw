
public class EternalGoal : Goal
{

    public EternalGoal(string name, string description, int points) : base(name, description, points){}

    public override string GetSummary()
    {
        return string.Format("{0} ({1})", GetName(), GetDescription());
    }

    public override bool IsComplete()
    {
        return false; // eternal goal will never be completed.
    }

    public override string ConvertObjectToString()
    {
        return $"EternalGoal|{GetName()}|{GetDescription()}|{GetPoint()}";
    }

    public override int RecordEvent()
    {
        return GetPoint();
    }
}