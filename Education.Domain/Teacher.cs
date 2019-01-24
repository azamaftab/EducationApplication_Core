using System;
using System.Collections.Generic;
using System.Text;

namespace Education.Domain
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public List<ClassTeacher> ClassTeachers { get; set; }
    }
}