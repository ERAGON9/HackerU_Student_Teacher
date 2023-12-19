using Hackeru_Student_Teacher.API.Models_API;
using Microsoft.EntityFrameworkCore;

namespace Hackeru_Student_Teacher.API.DataBase
{
    public class DbStudentTeacher: DbContext
    {
        // Properties
        public DbSet<Student> Students {  get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Question { get; set; }

        // C'tor
        public DbStudentTeacher()
        {}

        public DbStudentTeacher(DbContextOptions<DbStudentTeacher> options): base(options)
        {}

        // Functions
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=tryingDb.db");
        }
    }
}
