using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Input;

namespace StudentManagement
{

    public class Student
    {

        public int studentId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string Class { get; set; }
        public decimal gpa { get; set; }

    }



    public class StudentSearchViewModel: BaseViewModel
    {
        private string m_searchKeyword;
        public string SearchKeyword
        {
            get => m_searchKeyword;
            set
            {
                m_searchKeyword = value;
                OnPropertyChanged(nameof(SearchKeyword));
            }
        }

        private string m_selectedClass;

        public string SelectedClass
        {
            get => m_selectedClass;
            set
            {
                m_selectedClass = value;
                OnPropertyChanged(nameof(SelectedClass));
            }
        }

        private Student m_selectedStudent;
        public Student SelectedStudent
        {
            get => m_selectedStudent;
            set
            {
                m_selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand OpenDetailCommand { get; set; }

        public void DoOpenDetail()
        {
            var studentDetailViewModel = new StudenttDetailViewModel(SelectedStudent);
            Window1 studentDetail = new Window1();
            studentDetail.DataContext = studentDetailViewModel;
            studentDetail.ShowDialog();
        }


        public ObservableCollection<Student> Students { get; set; }
        private IStudentService m_studentSrv;
        public void DoReset()
        {
            SearchKeyword = null;
            SelectedClass = null;
        }
        private void DoSearch()
        {
            Students.Clear();
            var result = m_studentSrv.SearchStudent(SearchKeyword, SelectedClass);
            foreach (var s in result)
            {
                Students.Add(s);
            }
        }
        public StudentSearchViewModel()
        {
            m_studentSrv = new StudentServiceWithFile();
            Students = new ObservableCollection<Student>(m_studentSrv.SearchStudent(string.Empty, string.Empty));

            OpenDetailCommand = new ConditionalCommand(x => DoOpenDetail());
            SearchCommand = new ConditionalCommand(x => DoSearch());
            ResetCommand = new ConditionalCommand(x =>DoReset());
        }


    }
   

}
