using Exam;
using System.Text;
using static System.Console;

namespace Exam_OOP
{
    public class Subject
    {
        public int SubjectId;
        public string SubjectName;

        public static int number_of_questions { get; set; }
        public Exam Exam { get; set; }

        public Question[] questions;
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        public void CreateExam()
        {
            Write("Please Enter The Number Of Questions To Create : ");
            int Number;
            while (!int.TryParse(ReadLine(), out Number))
            {
                Write("Invalid input. Please enter a valid integer: ");
            }
            number_of_questions = Number;
            questions = new Question[number_of_questions];
            Clear();
            for (int i = 0; i < number_of_questions; i++)
            {
                if (Exam is PracticalExam)
                {
                    Clear();
                    questions[i] = new Question();
                    questions[i].Header = $"{i + 1}";
                    WriteLine("Choose One Answer Question");
                    Write($"Please Enter The Question {i + 1}: ");
                    questions[i].Body = ReadLine();
                    int mark = 0;
                    Write($"Please Enter Marks of Question {i + 1}: ");
                    while (!int.TryParse(ReadLine(), out mark))
                    {
                        Write("Invalid input. Please enter a valid integer: ");
                    }
                    questions[i].Mark = mark;

                    var mcqQuestion = new MCQQuestion();
                    mcqQuestion.AnswerMSQ = new Answer[4];
                    WriteLine("The Choices of The Question");
                    for (int j = 0; j < 4; j++)
                    {
                        Write($"Please Enter The Choice Number {j + 1}: ");
                        mcqQuestion.AnswerMSQ[j] = new Answer() { AnswerId = j + 1, AnswerText = ReadLine() };
                    }
                    questions[i].AnswersQuestion = mcqQuestion.AnswerMSQ;

                    Write("Please Enter The Correct Answer : ");
                    int correctAnswerIndex = 0;
                    while (!int.TryParse(ReadLine(), out correctAnswerIndex) || correctAnswerIndex == 0 || correctAnswerIndex > 4)
                    {
                        Write("Please enter the correct answer number: ");
                    }
                    questions[i].RightAnswer = correctAnswerIndex;


                }


                else if (Exam is FinalExam)
                {
                    Clear();
                    int x = 0;
                    Write($"Enter The Type of question ({i + 1})   (1 For True OR False ||  2 For MCQ ) : ");
                    while (!int.TryParse(ReadLine(), out x) || x == 0 || x > 2)
                    {
                        Write("Invalid input. Please enter a valid integer 1 or 2 : ");

                    }
                    if (x == 1)
                    {
                        Clear();
                        questions[i] = new Question();
                        questions[i].Header = $"{i + 1}";
                        WriteLine("True | False Question");
                        WriteLine($"Please Enter The Question {i + 1}: ");
                        questions[i].Body = ReadLine();

                        int mark = 0;
                        WriteLine($"Please Enter Mark of Question {i + 1}: ");
                        while (!int.TryParse(ReadLine(), out mark))
                        {
                            Write("Invalid input. Please enter a valid integer: ");
                        }
                        questions[i].Mark = mark;
                        WriteLine("Please Enter The Correct Answer Of Question (1 For True and 2 For False ) : ");
                        int correctAnswerIndex = 0;
                        while (!int.TryParse(ReadLine(), out correctAnswerIndex) || correctAnswerIndex == 0 || correctAnswerIndex > 2)
                        {
                            Write("Please enter the correct answer number (1) For True (2) For False: ");
                        }
                        questions[i].RightAnswer = correctAnswerIndex;

                        var AnswerTF = new TrueOrFalseQuestion();
                        AnswerTF.AnswersQuestion = new Answer[2];


                        AnswerTF.AnswersQuestion[0] = new Answer()
                        {
                            AnswerId = 1,
                            AnswerText = "True"
                        };
                        AnswerTF.AnswersQuestion[1] = new Answer()
                        {
                            AnswerId = 2,
                            AnswerText = "False"
                        };
                        questions[i].AnswersQuestion = AnswerTF.AnswersQuestion;

                    }

                    else if (x == 2)
                    {
                        Clear();
                        questions[i] = new Question();
                        questions[i].Header = $"{i + 1}";
                        WriteLine("Choose One Answer Question");
                        WriteLine($"Please Enter The Question {i + 1}: ");
                        questions[i].Body = ReadLine();

                        int mark = 0;
                        WriteLine($"Please Enter Marks  of Question {i + 1}: ");
                        while (!int.TryParse(ReadLine(), out mark))
                        {
                            WriteLine("Invalid input. Please enter a valid integer: ");
                        }
                        questions[i].Mark = mark;

                        var mcqQuestion = new MCQQuestion();
                        mcqQuestion.AnswerMSQ = new Answer[4];
                        WriteLine("The Choices of The Question");
                        for (int j = 0; j < 4; j++)
                        {
                            WriteLine($"Please Enter The Choice Number {j + 1}: ");
                            mcqQuestion.AnswerMSQ[j] = new Answer() { AnswerId = j + 1, AnswerText = ReadLine() };
                        }
                        questions[i].AnswersQuestion = mcqQuestion.AnswerMSQ;

                        WriteLine("Please Enter The Correct Answer : ");
                        int correctAnswerIndex = 0;
                        while (!int.TryParse(ReadLine(), out correctAnswerIndex) || correctAnswerIndex == 0 || correctAnswerIndex > 4)
                        {
                            WriteLine("Please enter the correct answer number: ");
                        }
                        questions[i].RightAnswer = correctAnswerIndex;


                    }
                }
            }
        }
    }
}








