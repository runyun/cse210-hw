using System;

class Program
{
    static void Main(string[] args)
    {
        int option = 0;
        Journal journal = new Journal();

        while (option != 5)
        {
            AskOption();

            option = int.Parse(Console.ReadLine());

            ProccessChosenOption(journal, option);
        }

        Console.WriteLine("Bye");
    }

    static void ProccessChosenOption(Journal journal, int optionIndex)
    {
        optionIndex -= 1;

        if (optionIndex == 0) 
        {
            WriteEntry(journal);        
        }
        else if (optionIndex == 1)
        {
            journal.DisplayJournal();
        }
        else if (optionIndex == 2)
        {
            journal._entries.Clear();

            string filename = AskFileName();
            journal.LoadJournal(filename);
        }
        else if (optionIndex == 3)
        {
            string filename = AskFileName();
            journal.SaveJournal(filename);
        }
    }
    static string AskFileName()
    {
        Console.Write("What is the file name? ");
        string filename = Console.ReadLine();
        
        return filename;
    }
    static void WriteEntry(Journal journal)
    {
        void DisplayQuote()
        {
            string quote = new QuoteGenerator().ChooseRandomQuote();
            Console.WriteLine();
            Console.WriteLine($"~~~ {quote} ~~~");
            Console.WriteLine();

        }

        DisplayQuote();

        string prompt = new PromptGenerator().ChooseRandomPrompt(); 
        Console.WriteLine(prompt);
        Console.Write("> ");

        string content = Console.ReadLine();
        string dateText = DateTime.Now.ToShortDateString();

        Entry entry = new Entry().CreateEntry(dateText, prompt, content);

        journal._entries.Add(entry);
    }

    static void AskOption()
    {
        List<string> options = new List<string>()
        {
            "Write",
            "Display",
            "Load",
            "Save",
            "Quit"
        };

        Console.WriteLine();
        Console.WriteLine("Please select one of the following choices: ");

        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }
        
        Console.Write("What would you like to do? ");
    }
}