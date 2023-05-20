using System.IO;

public class GoalManagement  
{
    private List<Goal> _goalList = new List<Goal>();
    private int _totalPoints = 0;
    
    private string _filename = "";

    private bool _isRecordEvent = false;

    public bool CheckUnsavedNewFile()
    {
        if (_filename == "")
        {
            return true;
        }
        return false;
    }

    public void RemindToSaveFile()
    {
        if(_goalList.Count() != 0)
        {
            if(CheckUnsavedNewFile() || CheckUnsavedExistFile() || _isRecordEvent)
            {
                Console.WriteLine("File not saved.");
                Console.Write("You want to save the file before you leave? (Y for yes): ");
                string respond = Console.ReadLine();

                if(respond.ToUpper() == "Y") 
                {
                    SaveFiles();
                }
            }
        }
    }
    public bool CheckUnsavedExistFile()
    {   
        (int _, List<Goal> savedGoalList) = LoadedGoalList();

        if (savedGoalList.Count != _goalList.Count())
        {
            return true;
        }

        return false;
    }

    public int GetToalPoints()
    {
        return _totalPoints;
    }

    public void RecordEvent()
    {
        List<string> goalNameList = (from goal in _goalList where !goal.IsComplete() select goal.GetName()).ToList();

        if(goalNameList.Count() == 0)
        {
            Console.WriteLine("You do not have unaccomplished goals.");
            return;
        }
        
        GetRecordEventMenu(goalNameList);

        int respond = int.Parse(Console.ReadLine());

        Goal selectedGoal = _goalList[respond - 1];

        int gainPoints = selectedGoal.RecordEvent();
        _totalPoints += gainPoints;

        Console.WriteLine();
        Console.WriteLine($"Congratulations! You have earned {gainPoints} points!");
        Console.WriteLine($"You now have {_totalPoints} points.");

        _isRecordEvent = true;
    }

    public void GetRecordEventMenu(List<string> goalNameList)
    {
        Console.WriteLine();

        Console.WriteLine("The goals are: ");

        for (int i = 0; i < goalNameList.Count(); i++)
        {
           Console.WriteLine(string.Format("{0}. {1}", i + 1, goalNameList[i]));
        }

        Console.Write("Which goal did you accomplished? ");
    }


    public void ShowGoalList()
    {
        Console.WriteLine();

        if (_goalList.Count == 0)
        {
            Console.WriteLine("You have not set any goals yet.");
            return;
        }

        Console.WriteLine("The goals are: ");
        for (int i = 0; i < _goalList.Count(); i++)
        {
            string isComplete = string.Format("[{0}]", _goalList[i].IsComplete() ? "X" : " ");
            Console.WriteLine(string.Format("{0}. {1} {2}", i + 1, isComplete, _goalList[i].GetSummary())); 
        }
    }

    public void CreateNewGoal(int newGoalType, List<string> respondList)
    {
        string name = respondList[0];
        string description = respondList[1];
        int points = int.Parse(respondList[2]);

        if(newGoalType == 1)
        {
            SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
            _goalList.Add(simpleGoal);
        }
        else if(newGoalType == 2)
        {
            EternalGoal eternalGoal = new EternalGoal(name, description, points);
            _goalList.Add(eternalGoal);
        }
        else if(newGoalType == 3)
        {
            int desiredTimes = int.Parse(respondList[3]);
            int finishedPoints = int.Parse(respondList[4]);

            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, desiredTimes, finishedPoints);
            _goalList.Add(checklistGoal);
        }
    }

    public void LoadFiles()
    {
        string filename = AskFileName();
        _filename = filename;

        (int totalPoint, List<Goal> goalList) = LoadedGoalList();

        _totalPoints = totalPoint;
        _goalList = goalList;
    }

    public (int, List<Goal>) LoadedGoalList()
    {
        GoalManagement goalManagement = new GoalManagement();
        List<Goal> goalList = new List<Goal>();

        List<string> goalStringList = File.ReadAllLines(_filename).ToList();

        int totalPoints = int.Parse(goalStringList[0]);
        goalStringList.RemoveAt(0);

        foreach(string line in goalStringList)
        {
            List<string> parts = line.Split('|').ToList();

            string goalType = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (goalType == "SimpleGoal")
            {
                bool isComplete = parts[4] == "FALSE" ? false : true;
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points, isComplete);

                goalList.Add(simpleGoal);
            }
            else if(goalType == "EternalGoal")
            {
                EternalGoal eternalGoal = new EternalGoal(name, description, points);

                goalList.Add(eternalGoal);
            }
            else if(goalType == "CheckListGoal")
            {
                int desiredTimes = int.Parse(parts[4]);
                int finishedPoints = int.Parse(parts[5]);
                int accomplishedTimes = int.Parse(parts[6]);
                ChecklistGoal checkListGoal = new ChecklistGoal(name, description, points, desiredTimes, finishedPoints, accomplishedTimes);
            
                goalList.Add(checkListGoal);
            }
        }

        return (totalPoints, goalList);
    }

    public void SaveFiles()
    {
        if(_goalList.Count() == 0)
        {
            return;
        }

        string filename = AskFileName();

        using(StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_totalPoints);

            foreach(Goal goal in _goalList) 
            {
                outputFile.WriteLine(goal.ConvertObjectToString());
            }
        }

        Console.WriteLine();
        Console.WriteLine("File Saved.");

        _isRecordEvent = false;
    }

    private string AskFileName()
    {
        Console.Write("What is thefile name for the goal file?  ");
        return Console.ReadLine();
    }
}