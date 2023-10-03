using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO.Course.ADONet.Lab7.Ex1
{
    internal class Program
    {
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;

            static List<Student> students = new List<Student>
        {
           new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
           new Student {First="Claire", Last="O’Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
           new Student {First="Irina", Last="Letova", ID=113, Scores= new List<int> {64, 78, 73, 46}},
           new Student {First="Max", Last="Smirnov", ID=114, Scores= new List<int> {89, 94, 94, 59}},
           new Student {First="Alex", Last="Korobicin", ID=115, Scores= new List<int> {99, 93, 97, 95}},
           new Student {First="Ron", Last="Doroty", ID=116, Scores= new List<int> {56, 78, 65, 70}},
           new Student {First="Fred", Last="Bugaev", ID=117, Scores= new List<int> {60, 71, 59, 87}},
           new Student {First="Nikolay", Last="Kulashenkov", ID=118, Scores= new List<int> {84, 88, 94, 82}},
           new Student {First="Erica", Last="Shumilova", ID=119, Scores= new List<int> {90, 93, 86, 93}},
           new Student {First="Lev", Last="Serov", ID=120, Scores= new List<int> {92, 86, 45, 56}},
        };
            static void Main(string[] args)
            {
                // создаем простой запрос на выборку тех стужентов, которые имеют показатель по первому экзамену больше 90 а по етвертому меньше 80               
                //IEnumerable<Student> studentQuery =
                //from student in students
                //where student.Scores[0] > 90 && student.Scores[3] < 80
                //orderby student.Last descending
                //select student;
                //    foreach (Student student in studentQuery)
                //    {
                //        Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]);
                //    }
                // первый вариант написать сортировку по первым буквам фамилии (но не по алфавиту) (менее предпочтительный)
                //var studentQuery2 =
                //from student in students
                //group student by student.Last[0];
                //foreach (var studentGroup in studentQuery2)
                //{
                //    Console.WriteLine(studentGroup.Key);
                //    foreach (Student student in studentGroup)
                //    {
                //        Console.WriteLine("   {0}, {1}", student.Last, student.First);
                //    }
                //}
                // второй вариант написать сортировку по первым буквам фамилии (но не по алфавиту) (более предпочтительный)
                //var studentQuery3 =
                //from student in students
                //group student by student.Last[0];
                //foreach (var groupOfStudents in studentQuery3)
                //{
                //    Console.WriteLine(groupOfStudents.Key);
                //    foreach (var student in groupOfStudents)
                //    {
                //        Console.WriteLine("   {0}, {1}", student.Last, student.First);
                //    }
                //}
                // упорядочивание группировки по алфавиту
                //var studentQuery4 =
                //from student in students
                //group student by student.Last[0] into studentGroup
                //orderby studentGroup.Key
                //select studentGroup;

                //foreach (var groupOfStudents in studentQuery4)
                //{
                //    Console.WriteLine(groupOfStudents.Key);
                //    foreach (var student in groupOfStudents)
                //    {
                //        Console.WriteLine("   {0}, {1}", student.Last, student.First);
                //    }
                //}

                // Ключевое слово let можно использовать для представления идентификатора для любого результата выражения в выражении запроса               
                //var studentQuery5 =
                //from student in students
                //let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                //where totalScore / 4 < student.Scores[0]
                //select student.Last + " " + student.First;

                //foreach (string s in studentQuery5)
                //{
                //    Console.WriteLine(s);
                //}

                // вычисляется общий результат для каждого Student в исходной последовательности, а затем вызовите метод Average(), использующий результаты запроса для вычисления среднего балла класса
                var studentQuery6 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                select totalScore;

                double averageScore = studentQuery6.Average();
                Console.WriteLine("Class average score = {0}", averageScore);

                IEnumerable<string> studentQuery7 =
                from student in students
                where student.Last == "Garcia"
                select student.First;

                Console.WriteLine("The Garcias in the class are:");
                foreach (string s in studentQuery7)
                {
                    Console.WriteLine(s);
                }


                var studentQuery8 =
                from student in students
                let x = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                where x > averageScore
                select new { id = student.ID, score = x };

                foreach (var item in studentQuery8)
                {
                    Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
                }   
            }
        }
    }
}
