using System;
using System.Collections.Generic;
using System.Text;

namespace Education.Domain
{
    public class ClassTeacher
    {
        public int ClassTeacherID { get; set; }
        public int ClassID { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teachers { get; set; }
        public Class Class { get; set; }
    }
}
