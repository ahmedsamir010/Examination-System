using Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Exam_OOP
{
    public class FinalExam : Exam
    {
        public const int MAX_ANSWER_CHOICES = 4;
        public const int TRUE_VALUE = 1;
        public const int FALSE_VALUE = 2;

        public FinalExam(int time, Subject subject) : base(time, subject) { }

        public override void ShowExam()
        {
            int totalMarks = 0;
            int totalMarksUser = 0;
            int[] userAnswers = new int[Subject.number_of_questions];

            for (int i = 0; i < Subject.number_of_questions; i++)
            {
                var question = Subject.questions[i];
                var isTrueFalse = question.AnswersQuestion.Length == 2;

                WriteLine($"{i + 1}. {question.Body} ({question.Mark} marks)");

                foreach (var answer in question.AnswersQuestion)
                {
                    WriteLine($"\t{answer.AnswerId}. {answer.AnswerText}");
                }

                int? userAnswer = null;
                do
                {
                    WriteLine("Please Enter your answer:");
                    try
                    {
                        userAnswer = Convert.ToInt32(ReadLine());
                    }
                    catch (FormatException)
                    {
                        userAnswer = null;
                    }
                } while (userAnswer == null || userAnswer < 1 || userAnswer > (isTrueFalse ? 2 : MAX_ANSWER_CHOICES));

                userAnswers[i] = userAnswer.Value;

                if (userAnswer == question.RightAnswer)
                {
                    totalMarksUser += question.Mark;
                }

                totalMarks += question.Mark;

                WriteLine();
            }

            Clear();
            WriteLine("Your Answers:");
            for (int i = 0; i < Subject.number_of_questions; i++)
            {
                var question = Subject.questions[i];
                var userAnswer = userAnswers[i];

                WriteLine($"Q){i + 1}. {question.Body} ({question.Mark} marks)");
                WriteLine($"\tCorrect answer: {question.AnswersQuestion[question.RightAnswer - 1].AnswerText}");
                WriteLine($"\tYour answer: {question.AnswersQuestion[userAnswer - 1].AnswerText}");
                WriteLine();
            }

            WriteLine($"Your Exam Grade is: {totalMarksUser} out of {totalMarks}.");
        }
    }


}
