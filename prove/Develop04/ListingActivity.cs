
public class ListingActivity : Activity
{
    private List<string> _promptList = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string name, string description) : base(name, description)
    {

    }
    
    public void StartActivity()
    {
        DisplayStartingMessage();

        AskAndSetDurationInSecond();

        DisplayGetReadyMessage();

        DisplayRandomPrompt();

        Console.WriteLine();
        UserListingWithinDuration();

        DisplayEndingMessage();
    }

    private void DisplayRandomPrompt()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        
        Console.WriteLine();
        Console.WriteLine($"-- {GetRandomPrompt()} --");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        DisplayPauseTextAnimate();
    }

    private string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int randomIndex = randomGenerator.Next(_promptList.Count());

        return _promptList[randomIndex];
    }
    
    private void UserListingWithinDuration()
    {
        int duration = GetDurationInSecond();
        int listingCount = 0;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            
            listingCount ++;
        }

        Console.WriteLine($"You listed {listingCount} items!");
    }
}