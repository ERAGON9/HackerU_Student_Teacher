using Hackeru_Student_Teacher.API.Models_API;
using Microsoft.EntityFrameworkCore;

namespace Hackeru_Student_Teacher.API.DataBase
{
    public class DbStudentTeacher: DbContext
    {
        // Properties
        DbSet<Student> Students {  get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Exam> Exams { get; set; }
        DbSet<Question> Question { get; set; }

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
