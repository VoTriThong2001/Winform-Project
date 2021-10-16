using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement
{
    public class StudenttDetailViewModel : BaseViewModel
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
        public StudenttDetailViewModel(Student student)
        {

            StudentIdDetail = student.studentId;
            FirstnameDetail = student.firstname;
            LastnameDetail = student.lastname;
            GenderDetail = student.gender;
            IsMale = (GenderDetail == "Male");

            EmailDetail = student.email;
            ClassDetail = student.Class;
            GpaDetail = student.gpa;

        }
    }
}
