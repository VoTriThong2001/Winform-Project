using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace StudentManagement
{
    class StudentServiceWithFile : IStudentService
    {
        public StudentServiceWithFile()
        {
            var data = File.ReadAllText("Student_Data.json");
            m_students = JsonSerializer.Deserialize<List<Student>>(data);
        }

        private IList<Student> m_students;
        public void DeleteStudentById(int id)
        {
            var deletedStudent = LoadStudentById(id);

            if (deletedStudent !=null)
            {
                m_students.Remove(deletedStudent);
            }
        }

        public Student LoadStudentById(long id)
        {
            return m_students.FirstOrDefault(x => x.studentId == id);
        }
        
        public IList<Student> SearchStudent(string keyword, string hutechClass)
        {
           
                var result = m_students.Where(s => (s.Class == hutechClass || hutechClass ==null) && (s.firstname == keyword || s.lastname == keyword || keyword ==null))
                               .OrderBy(s => s.firstname).ToList();
           

            foreach (var s in result)
            {
                Console.WriteLine(s);
              
            }
            return result;
        }

        public void UpdateOrCreateStudent(Student student)
        {
            if (student.studentId > 0 )
            {
                var updatedStudent = LoadStudentById(student.studentId);
                updatedStudent.studentId = student.studentId;
                updatedStudent.firstname = student.firstname;
                updatedStudent.lastname = student.lastname;
                updatedStudent.gender = student.gender;
                updatedStudent.email = student.email;
                updatedStudent.Class = student.Class;
                updatedStudent.gpa = student.gpa;
            } else
            {
                var newStudentId = m_students.Select(s => s.studentId).OrderByDescending(s => s).FirstOrDefault();
                student.studentId = newStudentId + 1;
                m_students.Add(student);
            }
        }
    }
}
