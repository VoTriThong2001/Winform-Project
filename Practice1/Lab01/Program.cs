using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab01
{
    class Student
    {
       
        private string studentID;
        private string fullname;
        private float averageScore;
        private string faculty;

        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }

        public float AverageScore
        {
            get { return averageScore; }
            set { averageScore = value; }
        }

        public string Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

        public Student()
        {

        }

        public Student(string id, string name, float score, string faculty)
        {
            StudentID = id;
            FullName = name;
            AverageScore = score;
            Faculty = faculty;
        }


        public void Input()
        {
            Console.Write("Nhập MSSV: ");
            StudentID = Console.ReadLine();
            Console.Write("Nhập Họ tên Sinh Viên: ");
            FullName = Console.ReadLine();
            Console.Write("Nhập Điểm TB: ");
            AverageScore = float.Parse(Console.ReadLine());

            Console.Write("Nhập Khoa: ");
            Faculty = Console.ReadLine();
        }

        public void Show()
        {
            Console.WriteLine("MSSV: {0} Họ Tên: {1} Khoa: {2} ĐiểmTB: {3}", this.StudentID, this.FullName, this.Faculty, this.AverageScore);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            List<Student> students = new List<Student>();
            students.Add(new Student("SV01", "Nguyen Van A", 8, "CNTT"));
            students.Add(new Student("SV02", "Nguyen Van A", 7, "CNTT"));
            students.Add(new Student("SV03", "Nguyen Van A", 9, "CNTT"));
            students.Add(new Student("SV04", "Nguyen Van A", 10, "xe"));
            students.Add(new Student("SV05", "Nguyen Van A", 8, "CNTT"));
            students.Add(new Student("SV06", "Nguyen Van A", 3,  "CNTT"));
            students.Add(new Student("SV07", "Nguyen Van A", 4, "CNTT"));


            var cnttStudents = students.FindAll(x => x.Faculty == "CNTT");
            var avgOver5 = students.FindAll(x => x.AverageScore >= 5);
            var cnttAndAvgOver5 = students.FindAll(x => x.Faculty == "CNTT" && x.AverageScore >= 5);
            var maxCNTTAvg = cnttStudents.Max(x => x.AverageScore);
            
            Console.WriteLine("1.1 (Khóa CNTT) ");
            foreach (var item in cnttStudents)
            {
                Console.WriteLine("MSSV: {0} Họ Tên: {1} Khoa: {2} ĐiểmTB: {3}", item.StudentID, item.FullName, item.Faculty, item.AverageScore);
            }

            Console.WriteLine("\n1.2: (TB lớn hơn 5) ");
            foreach (var item in avgOver5)
            {
                Console.WriteLine("MSSV: {0} Họ Tên: {1} Khoa: {2} ĐiểmTB: {3}", item.StudentID, item.FullName, item.Faculty, item.AverageScore);
            }

            Console.WriteLine("\n1.3: (Sắp xếp theo điểm TB tăng dần) ");
            List<Student> sortStudents = students.OrderBy(x => x.AverageScore).ToList();
            foreach (Student sv in sortStudents)
            {
                sv.Show();
            }

            Console.WriteLine("\n1.4: (có điểm TB lớn hơn bằng 5 và khóa CNTT)");
            foreach (var item in cnttAndAvgOver5)
            {
                Console.WriteLine("MSSV: {0} Họ Tên: {1} Khoa: {2} ĐiểmTB: {3}", item.StudentID, item.FullName, item.Faculty, item.AverageScore);
            }

            Console.WriteLine("\n1.5: (có điểm TB lớn hơn bằng 5 và khóa CNTT)");
            foreach (var item in cnttStudents)
            if (item.AverageScore == maxCNTTAvg)
            {
                Console.WriteLine("MSSV: {0} Họ Tên: {1} Khoa: {2} ĐiểmTB: {3}", item.StudentID, item.FullName, item.Faculty, item.AverageScore);             
            }

            Console.ReadKey();
        }
    }
}
