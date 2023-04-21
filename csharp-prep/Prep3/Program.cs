using System;

class Program
{
    static void Main(string[] args)
    {
        bool startGame = false;

        do{
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            bool gameover = false;
            int guessCount = 0;

            do {
                Console.Write("what is your guess? ");
                int guess = int.Parse(Console.ReadLine());

                string result = "";
                if (magicNumber > guess)
                {
                    result = "Higher";
                }
                else if (magicNumber < guess)
                {
                    result = "Lower";
                }
                else
                {
                    result = "You guessed it!";
                    gameover = true;
                }

                guessCount += 1;
                Console.WriteLine(result);
            }
            while (!gameover);
        
            Console.WriteLine($"You've guessed {guessCount} times.");

            Console.Write("Want to play again?('yes' to continue) ");
            string wantPlay = Console.ReadLine();
            if (wantPlay.ToUpper() == "YES")
            {
                startGame = true;
            }
            else
            {
                startGame = false;
            }
        }
        while (startGame);

        Console.WriteLine("Good bye");
    }
}