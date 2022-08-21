using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher osman = new Teacher(mediator);
            osman.Name = "Osman";
            mediator.Teacher = osman;

            Student hamza = new Student(mediator);
            hamza.Name = "Hamza";

            Student eymen = new Student(mediator);
            eymen.Name = "Eymen";

            mediator.Students = new List<Student> { hamza, eymen };
            osman.SendNewImageUrl("slide1.jpg");

            osman.RecieveQuestion("is it true?", hamza);

            Console.ReadLine();

        }
    }
    abstract class CourseMember
    {
        protected Mediator Mediator;
        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }
    class Teacher : CourseMember
    {
        public string Name { get; internal set; }

        public Teacher(Mediator mediator) : base(mediator)
        {

        }
        public void RecieveQuestion(string question, Student student)//soru gönderme
        {
            Console.WriteLine("Teacher recieved a quesiton from {0},{1}", student.Name, question);
        }
        public void SendNewImageUrl(string url)//öğretmen slayt değiştiğinde
                                               //ilgili işlemleri yapacak operasyon(url de değişir.)
        {
            Console.WriteLine("Teacher changed slide: {0}", url);
            Mediator.UpdateImage(url);
        }
        public void AnswerQuestion(string answer, Student student)//soru cevaplama
        {
            Console.WriteLine("Teacher answered question {0},{1}", student.Name, answer);
        }
    }
    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }
        public string Name { get; set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} received image:{0}", url,Name);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student received answer {0}", answer);
        }
    }
    class Mediator //iletişimi sağlayacak sistemimiz.
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }
        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }
        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
