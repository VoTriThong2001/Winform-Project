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
			var result = Name.CompareTo(other.Name);

			if (result == 0)
				result = StudentId.CompareTo(other.StudentId);

			return result;
		}
	
	}

	static void Main(string[] args)
	{
		List<Student> students = new List<Student>()
		{
			new Student () {ID = 1, Name = "Nguyen Van A" },
			new Student () {ID = 2, Name = "Tran Thi B" },
			new Student () {ID = 2, Name = "Pham Minh C" },
		};
		students.Sort();

		foreach (var student in students)
        {
			Console.WriteLine(student.Name);
        }
		Console.ReadLine();
	}

}

