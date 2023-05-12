using System;

class Program
{
    static void Main(string[] args)
    {
        int option = 0;

        while(option != 4)
        {
            DisplayMenu();

            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Numbers only");
            }

            if(option == 1)
            {
                string description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
                BreathingActivity breathingActivity = new BreathingActivity("Breathing", description);
                breathingActivity.StartActivity();
            } 
            else if(option == 2)
            {
                string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
                ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting", description);
                reflectingActivity.StartActivity();
            }
            else if(option == 3)
            {
                string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
                ListingActivity listingActivity = new ListingActivity("Listing", description);
                listingActivity.StartActivity();
            }
        }

        Console.WriteLine();
        Console.WriteLine("Good bye");
    }

    private static void DisplayMenu()
    {
        Console.Clear();

        Console.WriteLine("Menu Options:");
        Console.WriteLine($"{GetOptionsString()}");
        Console.Write("Select a choice from the menu: ");
    }

    private static string GetOptionsString()
    {
        List<string> optionList = new List<string>(){
            "breathing",
            "reflecting",
            "listing"
        };

        string result = "";

        for (int i = 0; i < optionList.Count(); i++)
        {
           result += $"{i+1}. Start {optionList[i]} activity \n" ;
        }

        result += $"{optionList.Count + 1}. Quit \n" ;

        return result;
    }
}