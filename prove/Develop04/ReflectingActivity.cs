
public class ReflectingActivity : Activity
{
    private List<string> _promptList = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _reflectQuestionList = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity(string name, string description) : base(name, description)
    {

    }

    public void StartActivity()
    {
        DisplayStartingMessage();

        AskAndSetDurationInSecond();

        DisplayGetReadyMessage();

        DisplayRandomPrompt();
        Console.ReadLine();

        DisplayStartPonderMessage();
        
        DisplayRandomReflectQuestion();

        DisplayEndingMessage();
    }

    private void DisplayRandomPrompt()
    {
        Console.WriteLine("Consider the following prompt:");

        Console.WriteLine();
        Console.WriteLine($"-- {GetRandomPrompt()} --");
        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press enter to continue.");
    }

    private void DisplayStartPonderMessage()
    {
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in:  ");
        DisplayPauseTextAnimate();
    }

    private void DisplayRandomReflectQuestion()
    {
        Console.Clear();

        int ponderTimeInSecond = 10;
        int duration = GetDurationInSecond();

        while (duration > 0)
        {
            Console.Write($"> {GetRandomReflectQuestion()} ");

            if (duration > ponderTimeInSecond)
            {
                DisplayPauseAnimate(ponderTimeInSecond);
            }
            else
            {
                DisplayPauseAnimate(duration);
            }

            Console.WriteLine();

            duration -= ponderTimeInSecond;
        }
    }

    private int GetRandomNumber(int max)
    {
        Random randomGenerator = new Random();
        return randomGenerator.Next(max);
    }

    private string GetRandomPrompt()
    {
        int randomIndex = GetRandomNumber(_promptList.Count());
        return _promptList[randomIndex];
    }

    private string GetRandomReflectQuestion()
    {
        int randomIndex = GetRandomNumber(_reflectQuestionList.Count());
        return _reflectQuestionList[randomIndex];
    }
}