
public class Activity
{
    private string _name, _description;
    private int _durationInSecond;

    public Activity(string name, string description)
    {
        _name = name + " Activity";
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        
        Console.WriteLine($"{_description}");
        Console.WriteLine();
        
        Console.Write("How long, in seconds, would you like for your session? ");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        DisplayPauseAnimate();
        Console.WriteLine();
        
        Console.WriteLine($"You have completed another {_durationInSecond} seconds of the {_name}.");
        DisplayPauseAnimate();
    }

    public void DisplayPauseAnimate(int second = 5)
    {
        List<string> spinList = new List<string>(){
            "|",
            "/",
            "-",
            "\\"
        };

        int spinSymbolIndex = 0;

        for (int i = 0; i < second; i++)
        {
            Console.Write(spinList[spinSymbolIndex]);
            Thread.Sleep(1000); 

            spinSymbolIndex ++;
            if (spinSymbolIndex > spinList.Count() - 1) { spinSymbolIndex = 0; }

            Console.Write("\b \b"); // \b is back arrow. This could replace one caracter.
        }

    }

    public void DisplayPauseTextAnimate(int second = 5)
    {
        for (int i = second; i > 0; i--)      
        {
            Console.Write(i);
            Thread.Sleep(1000); 
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public void DisplayGetReadyMessage()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplayPauseAnimate();
        Console.WriteLine();
    }

    public void AskAndSetDurationInSecond()
    {
        int duration = 0;

        while (true)
        {
            try
            {
                duration = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
               Console.Write("Numbers only. Try again: ");
            }
            catch (OverflowException)
            {
                Console.Write("Too long. Try again: ");
            }

            if(duration < 0)
            {
                Console.Write("Positive Integer only. Try again: ");
            }

            if (duration > 0)
            {
                _durationInSecond = duration;
                break;
            }
        }
    }

    public void SetDurationInSecond(int duration)
    {
        _durationInSecond = duration;
    }

    public int GetDurationInSecond()
    {
        return _durationInSecond;
    }
}