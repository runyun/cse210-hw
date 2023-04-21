using System;

class Program
{
    static void Main(string[] args)
    {
        string letter = "";

        Console.Write("What is the grade percentage? ");
        
        int grade = int.Parse(Console.ReadLine());

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else 
        {
            letter = "F";
        }

        string levelSign = "";
        int lastDigit = grade % 10;
        if (lastDigit >= 7)
        {
            levelSign = "+";
        }
        else if (lastDigit < 3)
        {
            levelSign = "-";
        }

        if (letter == "F")
        {
            levelSign = "";
        }

        if (letter =="A" && levelSign == "+")
        {
            levelSign = "";
        }

        Console.WriteLine(letter + levelSign);

        if (grade >= 70)
        {
            Console.WriteLine("Congratulation!");
        }
        else
        {
            Console.WriteLine("Keep up!");
        }
    }
}