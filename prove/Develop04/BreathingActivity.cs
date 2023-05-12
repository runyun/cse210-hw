
public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {

    }

    public void StartActivity()
    {
        DisplayStartingMessage();

        AskAndSetDurationInSecond();

        DisplayGetReadyMessage();

        StartBreathingAnimate();

        DisplayEndingMessage();
    }

    private void StartBreathingAnimate()
    {
        int frequencyInSecond = 5;
        int set = frequencyInSecond * 2; // Breath in 5 seconds; Breath out 5 second. This is a set.
        int setAmount = GetSetAmount(set);
        SetDurationInSecond(set * setAmount);
        

        Console.WriteLine($"According to your desired activity duration, we will have {set * setAmount} seconds activity.");
        Console.WriteLine();

        for (int i = 0; i < setAmount; i++)
        {
            Console.Write("Breathe in... ");
            DisplayPauseTextAnimate(5);

            Console.Write("Breathe out... ");
            DisplayPauseTextAnimate(5);
            Console.WriteLine();
        }
    }

    private int GetSetAmount(int setInSecond)
    {
        int set = 0;
        int duration = GetDurationInSecond();

        if(duration < setInSecond)
        {
            set = 1;
        }
        else if(duration % setInSecond >= 5)
        {
            set = duration / setInSecond + 1; 
        }
        else if(duration % setInSecond < 5)
        {
            set = duration / setInSecond; 
        }

        if(set == 0) {set = 1;} // duration is under 14 second

        return set;
    }
}