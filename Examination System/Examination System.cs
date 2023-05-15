using Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exam_OOP
{
    public abstract class Exam
    {
        public int Time { get; set; }
        public int NumQuestions { get; set; }
        public Question[] Questions { get; set; }
        public Subject Subject { get; set; }


        public abstract void ShowExam();

       
        public Exam(int time, Subject Subject)
        {
            this.Subject= Subject;
            this.Time = time;
        }
    
    }

}
