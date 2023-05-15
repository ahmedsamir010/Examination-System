using System;
using System.Diagnostics;
using static System.Console;

namespace Exam_OOP
{
    internal class Program
    {
        static void Main()
        {
            var subject = new Subject(1, "C#");

            Write("Please Enter The Type Of Exam To Create (1 For Practical and 2 For Final): ");
            int examType;
            while (!int.TryParse(ReadLine(), out examType) || (examType != 1 && examType != 2))
                Write("Invalid input. Please enter a valid number (1 For Practical and 2 For Final): ");

            Write("Please Enter The Time Of Exam in Minutes: ");
            int examTime;
            while (!int.TryParse(ReadLine(), out examTime) || examTime <= 0)
                Write("Invalid input. Please enter a valid number: ");

            Exam exam;
            if (examType == 1)
                exam = new PracticalExam(examTime, subject);
            else
                exam = new FinalExam(examTime, subject);

            subject.Exam = exam;
            subject.CreateExam();

            Clear();
            WriteLine("Do You Want To Start Exam (y | n): ");
            char startExam;
            while (!char.TryParse(ReadLine(), out startExam) || (startExam != 'y' && startExam != 'n'))
                Write("Invalid input. Please enter a valid char (y For Yes || n For No): ");

            Clear();
            if (startExam == 'y')
            {
                var stopwatch = new Stopwatch();
                try
                {
                    stopwatch.Start();
                    exam.ShowExam();
                }
                catch (Exception e)
                {
                    WriteLine($"An error occurred during the exam: {e.Message}");
                }
                finally
                {
                    stopwatch.Stop();
                    WriteLine($"The Elapsed Time = {stopwatch.Elapsed}");
                }
            }
            else
            {
                WriteLine("HaHa.. Bye Bye .. With My Best Wishes");
            }
        }
    }
}
