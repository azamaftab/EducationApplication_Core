using System.Collections.Generic;

namespace Education.Domain
{
    public class Class
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        //public List<Student> Students { get; set; }
        //public List<Teacher> Teachers { get; set; }
        public List<ClassTeacher> ClassTeachers { get; set; }
    }
}
