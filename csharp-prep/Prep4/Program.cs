using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numberList = new List<int>();

        while (true)
        {
            Console.Write("Enter number: ");
            int newNumber = int.Parse(Console.ReadLine());

            if (newNumber == 0)
            {
                break;
            }

            numberList.Add(newNumber);
        }
        
        Console.WriteLine("The sum is: " + numberList.Sum());
        Console.WriteLine("The average is: " + numberList.Average());
        Console.WriteLine("The largest number is: " + numberList.Max());

        numberList.Sort();

        int smallestPositiveNumber = 0;
        foreach(int value in numberList)
        {
            if (value > 0)
            {
                smallestPositiveNumber = value;
                break;
            }
        }        

        Console.WriteLine("The smallest positive number is: " + smallestPositiveNumber);

        Console.WriteLine("The sorted list is: ");
        foreach(int value in numberList)
        {
            Console.WriteLine(value);
        }
    }
}