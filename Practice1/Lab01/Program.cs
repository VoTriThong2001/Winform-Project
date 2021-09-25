using System;

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

            Console.Write("Nhập tổng số sinh viên N = ");
            int N = Convert.ToInt32(Console.ReadLine());
            Student[] arrStudents = new Student[N];
            Console.WriteLine("\n ====Nhập Danh Sách sinh viên====");
            for (int i=0; i<N; i++)
            {
                Console.WriteLine("\n - Nhập sinh viên thứ {0}", i + 1);
                arrStudents[i] = new Student();
                arrStudents[i].Input();
            }
            Console.WriteLine("\n ====Xuất Danh Sách sinh viên====");
            foreach (Student sv in arrStudents)
            {
                sv.Show();
            }
            Console.ReadKey();
        }
    }
}
