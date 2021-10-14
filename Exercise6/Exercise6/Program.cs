using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonString = File.ReadAllText("Student_data_Handon.json");
            var students = JsonSerializer.Deserialize<List<Student>>(jsonString);

            Console.WriteLine("List all students of the class '19DTHQA2' ");
            var result = students.Where(s=>s.Class == "19DTHQA2")
                                .OrderBy(s=> s.FirstName)
                                .Select(s=>s.FirstName + " " + s.LastName + " - " + s.StudentId);

            foreach (var s in result)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\n=====Statistic student by gender, class, city=====");
            Console.WriteLine("\nBy gender:");
            var genderCount = students.GroupBy(s => s.Gender, s => s,
                                          (k, v) => new {
                                              Gender = k,
                                              Number = v.Count()

                                          }
                                          );
            foreach (var s in genderCount)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nBy class:");
            var classCount = students.GroupBy(s => s.Class, s => s,
                                          (k, v) => new {
                                              Class = k,
                                              Number = v.Count()

                                          }
                                          );

            foreach (var s in classCount)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nBy city:");
            var cityCount=students.GroupBy(s => s.City, s => s,
                                          (k, v) => new {City = k,
                                                        Number = v.Count()

                                                        }
                                          );

            foreach (var s in cityCount)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\n=====GPA of all students=====");
            foreach (var s in students)
            {
                Console.WriteLine("\n");
                Console.WriteLine(s.FirstName);
                var gpa = s.Exam.Average(x => x.Point);
                Console.WriteLine("GPA: {0}",gpa);
            }


            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

            Console.WriteLine("\n=====Students with GPA > 7 & No subject < 5=====");
            var allExams = students.SelectMany(x => x.Exam).ToList();
            foreach (var s in students)
            {
                
                var gpa = s.Exam.Average(x => x.Point);
                if (gpa > 7 && s.Exam.All(x => x.Point >= 5))
                {
                    Console.WriteLine("\n");
                    Console.WriteLine(s.FirstName);
                    Console.WriteLine("GPA: {0}", gpa);
                }
               
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

            Console.WriteLine("\n=====Student with highest score per subject=====");
            
            var groupedBySubject = allExams.GroupBy(c => c.Subject);
            foreach (var examGroup in groupedBySubject)
            {
                Console.WriteLine(examGroup.Key + ":");
                decimal maxPoint = examGroup.Max(x => x.Point);
                var studentsWithMaxPoint = students.Where(s => s.Exam.Any(c => c.Subject == examGroup.Key && c.Point == maxPoint));
                foreach (var student in studentsWithMaxPoint)
                {
                    Console.WriteLine("\t" + student.FirstName + " " + student.LastName + " - " + maxPoint);
                }
            }




            Console.WriteLine("\nStudents with subject less than 5:");
            var failed = students.Where(s => s.Exam.Any(e => e.Point < 5)).ToList();

            foreach (var s in failed)
            {
                Console.WriteLine(s.FirstName);
                var repeatedSubj = s.Exam.Where(e => e.Point < 5).ToList();
                foreach (var subj in repeatedSubj)
                {
                    Console.WriteLine($" - {subj.Subject}");
                }
            }

        }
        

}

    public class Student
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Class { get; set; }
        public List<Result> Exam { get; set; }
    }

    public class Result
    {
        public string Subject { get; set; }
        public decimal Point { get; set; }
    }
}
