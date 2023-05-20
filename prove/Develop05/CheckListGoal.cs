
public class ChecklistGoal : Goal
{
    private int _desiredTimes, _accomplishTimes, _finishedPoints;

    public ChecklistGoal(string name, string description, int points, int desiredTimes, int finishedPoints, int accomplishedTimes = 0) : base(name, description, points)
    {
        _desiredTimes = desiredTimes;
        _finishedPoints = finishedPoints;
        _accomplishTimes = accomplishedTimes;
    }

    public override string GetSummary()
    {
        return string.Format("{0} ({1}) -- Currently completed: {2}/{3}", GetName(), GetDescription(), _accomplishTimes, _desiredTimes);
    }

    public override bool IsComplete()
    {
        if(_desiredTimes == _accomplishTimes)
        {
            return true;
        }
        return false;
    }

    public override string ConvertObjectToString()
    {
        return string.Format("CheckListGoal|{0}|{1}|{2}|{3}|{4}|{5}", GetName(), GetDescription(), GetPoint(), _desiredTimes, _finishedPoints, _accomplishTimes);
    }

    public override int RecordEvent()
    {
        _accomplishTimes += 1;
        
        if(IsComplete())
        {
            return _finishedPoints;
        }
        else
        {
            return GetPoint();
        }
    }
}