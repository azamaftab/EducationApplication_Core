namespace Education.Domain
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int ClassID { get; set; }
        public Class Class { get; set; }
    }
}
