using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2010;
        job1._endYear = 2012;

        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Manager";
        job2._startYear = 2012;
        job2._endYear = 2015;

        Resume resume = new Resume();
        resume._name = "Yun";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}