using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace StudentManagement
{
    public class Student
    {

        public int StudentID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public decimal Gpa { get; set; }

    }
}
