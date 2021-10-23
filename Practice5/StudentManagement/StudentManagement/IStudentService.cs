using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement
{
    public interface IStudentService
    {
        IList<Student> SearchStudent(string keyword, string hutechClass);

        Student LoadStudentById(int id);

        void UpdateOrCreateStudent(Student student);

        void DeleteStudentById(int id);

        
    }
    public interface ICloseable
    {
        event EventHandler CloseRequest;
    }
}
