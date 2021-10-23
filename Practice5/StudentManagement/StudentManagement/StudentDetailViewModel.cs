using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement
{
    

    public class StudentDetailViewModel : BaseViewModel,ICloseable
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
        public ICommand CancelCommand { get; set; }

        private readonly IStudentService m_studentService;
        public StudentDetailViewModel(IStudentService studentService, int studentId)
        {
            m_studentService = studentService;

            var student = m_studentService.LoadStudentById(studentId);
            StudentIdDetail = student.studentId;
            FirstnameDetail = student.firstname;
            LastnameDetail = student.lastname;
            GenderDetail = student.gender;
            EmailDetail = student.email;
            ClassDetail = student.Class;
            GpaDetail = student.gpa;

            SaveCommand = new ConditionalCommand(x => DoSave());
            CancelCommand = new ConditionalCommand(x => DoCancel());
        }

        public event EventHandler CloseRequest;
        private void DoCancel()
        {
            var handler = CloseRequest;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public Student m_student;

        private void DoSave()
        {
            m_student = new Student();
            m_student.studentId = StudentIdDetail;
            m_student.firstname = FirstnameDetail;
            m_student.lastname = LastnameDetail;
            m_student.gender = GenderDetail;
            m_student.email = EmailDetail;
            m_student.Class = ClassDetail;
            m_student.gpa = GpaDetail;

            m_studentService.UpdateOrCreateStudent(m_student);
        }
    }
}
