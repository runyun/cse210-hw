using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        GoalManagement goalManagement = new GoalManagement();

        while (choice != 6)
        {
            int totalPoints = goalManagement.GetToalPoints();

            ShowMenu(totalPoints);

            choice = int.Parse(Console.ReadLine());

            ProccessChoice(choice, goalManagement);
        }
    }

    private static void ProccessChoice(int choice, GoalManagement goalManagement)
    {
        if(choice == 1)
        {
            int newGoalType = GetNewGoalType();

            bool isCheckListGoal = newGoalType == 3 ? true : false;
            List<string> respondList = AskSettingQuestions(isCheckListGoal);

            goalManagement.CreateNewGoal(newGoalType, respondList);
        }
        else if(choice == 2)
        {
            goalManagement.ShowGoalList();
        }
        else if(choice == 3)
        {
            goalManagement.SaveFiles();
        }
        else if(choice == 4)
        {
            goalManagement.LoadFiles();
        }
        else if(choice == 5)
        {
            goalManagement.RecordEvent();
        }
        else if(choice == 6)
        {
            goalManagement.RemindToSaveFile();

            Console.WriteLine();
            Console.WriteLine("Good bye");
            Console.WriteLine();
        }
    }

    private static void ShowMenu(int totalPoints)
    {
        List<string> options = CreateMenuOptions();

        Console.WriteLine();
        Console.WriteLine("========================");
        Console.WriteLine($"You have {totalPoints} points.");
        Console.WriteLine("========================");
        Console.WriteLine();
        Console.WriteLine("Menu Options");

        for (int i = 0; i < options.Count(); i++)
        {
           Console.WriteLine($"{i + 1}. {options[i]}");
        }

        Console.Write("Select a choice from the menu: ");
    }

    private static List<string> CreateMenuOptions()
    {
        List<string> options = new List<string>()
        {
            "Create New Goal",
            "List Goals",
            "Save Goals",
            "Load Goals",
            "Record Event",
            "Quit",
        };

        return options;
    }

    private static int GetNewGoalType()
    {
        int newGoalType = 0;

        while (newGoalType < 1 || newGoalType > 3)
        {
            ShowNewGoalOptions();
            newGoalType = int.Parse(Console.ReadLine());
        }

        return newGoalType;
    }

    private static List<string> AskSettingQuestions(bool isChecklistGoal)
    {

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associtated with this goal? ");
        string points = Console.ReadLine();

        List<string> respondList = new List<string>()
        {
            name, description, points
        };
        
        if(isChecklistGoal)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            string desiredTimes = Console.ReadLine();

            Console.Write("What is the bonus for accomplishing it that many times? ");
            string finishedPoints = Console.ReadLine();

            respondList.Add(desiredTimes);
            respondList.Add(finishedPoints);
        }

        return respondList;
    }

    private static void ShowNewGoalOptions()
    {
        Console.WriteLine();
        Console.WriteLine("The types of Goals are:");

        List<string> goalTypeList = new List<string>()
        {
            "Simple Goal",
            "Eternal Goal",
            "Checklist Goal",
        };

        for (int i = 0; i < goalTypeList.Count(); i++)
        {
           Console.WriteLine($"{i + 1}. {goalTypeList[i]}");
        }

        Console.Write("Which type of goal would you like to create? ");
    }
}