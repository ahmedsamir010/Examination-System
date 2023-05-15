using Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Exam_OOP
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int time, Subject subject) : base(time, subject) { }
        public override void ShowExam()
        {
            int totalMarks = 0;
            int totalMarksUser = 0;
            int answer = 0;
            int[] userAnswers = new int[Subject.number_of_questions];

            for (int i = 0; i < Subject.number_of_questions; i++)
            {
                var question = Subject.questions[i];
                DisplayQuestion(question);

                while (!int.TryParse(ReadLine(), out answer) || answer == 0 || answer > 4)
                {
                    WriteLine("Please enter the correct answer number: ");
                }

                if (answer == question.RightAnswer)
                    totalMarksUser += question.Mark;
                totalMarks += question.Mark;

                WriteLine("\n========================================");
                userAnswers[i] = answer;
            }

            Clear();
            DisplayUserAnswers(userAnswers);

        }

        private void DisplayQuestion(Question question)
        {
            WriteLine($"{question.Header}: {question.Body} ");

            foreach (var answer in question.AnswersQuestion)
            {
                Write($"{answer.AnswerId}.{answer.AnswerText}\t");
            }

            WriteLine();
            WriteLine("-----------------------------------------");
        }
        private void DisplayUserAnswers(int[] userAnswers)
        {
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
        }
    }
}
