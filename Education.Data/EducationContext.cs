using Education.Domain;
using Microsoft.EntityFrameworkCore;

namespace Education.Data
{
    public class EducationContext : DbContext
    {
        public EducationContext(DbContextOptions<EducationContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"server =  NX00444\MSSQLSERVER2016; database = EducationDB; Trusted_Connection=true;");
        //}
    }
}
