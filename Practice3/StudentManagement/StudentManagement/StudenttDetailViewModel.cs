using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement
{
    public class StudenttDetailViewModel
    {   int StudentId;
        string Firstname, Lastname, Gender, Email;
        decimal Gpa;

        public StudenttDetailViewModel(Student student)
        {
            
            StudentId = student.StudentID;
            Firstname = student.Firstname;
            Lastname = student.Lastname;
            Gender = student.Gender;
            Email = student.Email;
            Gpa = student.Gpa;

        }
    }
}
