using System;
using System.Collections.Generic;

namespace _01_Exercise3
{

	public class Student : IComparable<Student>
	{
		public int StudentId { get; set; }

		public String Name { get; set; }

		public int CompareTo(Student other)
		{
			var result = StudentId.CompareTo(other.StudentId);

			if (result == 0)
				result = Name.CompareTo(other.Name);

			return result;
		}

	}
	public class Use
    {
		static void Main(string[] args)
		{
			List<Student> students = new List<Student>()
		{
			new Student () {StudentId = 5, Name = "Nguyen Van A" },
			new Student () {StudentId= 2, Name = "Tran Thi B" },
			new Student () {StudentId = 8, Name = "Pham Minh C" },
			new Student () {StudentId = 1, Name = "Vo Van D" },
		};
			students.Sort();

			foreach (var student in students)
			{
				Console.WriteLine(student.Name);
			}
			Console.ReadLine();
		}
	}
	

}

