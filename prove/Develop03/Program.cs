using System;

class Program
{
    static void Main(string[] args)
    {
        string scriptureString = "And I was led by the Spirit, not knowing beforehand the things which I should do.";
        Reference reference = new Reference("1 Nephi", 4, 6);
        
        Scripture scripture = new Scripture(reference, scriptureString);

        string userReply = "";
        while(userReply != "quit")
        {
            Console.Clear();

            string renderedText = scripture.GetRenderedText();
            Console.WriteLine(renderedText);
            
            if(scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue");
            Console.WriteLine("Or type 'quit' to finish");
            Console.WriteLine("Or type 'b' to recover: ");
            userReply = Console.ReadLine();

            if (userReply.ToUpper() == "B")
            {
                scripture.RecoverWords();
            }
            else
            {
                scripture.HideWords();
            }
        }

        Console.WriteLine("Bye");
    }
}