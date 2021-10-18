using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace StudentManagement
{
    public class StudentDetailViewModel : BaseViewModel
    {
        public int StudentIdDetail { get; set; }
        public string FirstnameDetail { get; set; }
        public string LastnameDetail { get; set; }
        public string EmailDetail { get; set; }
        private string m_GenderDetail;
        public string GenderDetail
        {
            get => m_GenderDetail;
            set
            {
                m_GenderDetail = value;
                OnPropertyChanged(nameof(GenderDetail));
            }
        }
        private string m_ClassDetail;
        public string ClassDetail
        {
          get => m_ClassDetail; 
          set
            {
                m_ClassDetail = value;
                OnPropertyChanged(nameof(ClassDetail));
            }
        }
        public decimal GpaDetail { get; set; }
        private bool m_IsMale;
        

        public bool IsMale
        {
            get => m_IsMale; set
            {
                m_IsMale = value;
                OnPropertyChanged(nameof(IsMale));
            }
        }

        public bool IsFemale
        {
            get => !m_IsMale; set
            {
                m_IsMale = !value;
                OnPropertyChanged(nameof(IsFemale));
            }
        }

        public ICommand SaveCommand { get; set; }

        private readonly IStudentService m_studentService;
        public StudentDetailViewModel(IStudentService studentService, int studentId)
        {
            m_studentService = studentService;

            var student = m_studentService.LoadStudentById(studentId);
            StudentIdDetail = student.studentId;
            FirstnameDetail = student.firstname;
            LastnameDetail = student.lastname;
            GenderDetail = student.gender;
            IsMale = (GenderDetail == "Male");

            EmailDetail = student.email;
            ClassDetail = student.Class;
            GpaDetail = student.gpa;

            SaveCommand = new ConditionalCommand(x => DoSave());
            SaveCommand = new ConditionalCommand(x => DoCancel());
        }

        private void DoCancel()
        {
            throw new NotImplementedException();
        }
        public IList<Student> m_student;
        private void DoSave()
        {
            throw new NotImplementedException();
        }
    }
}
