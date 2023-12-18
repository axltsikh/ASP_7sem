using System.Data.Entity;
using ThirdLab.Models;

namespace ThirdLab.Database
{
    public class StudentContext:DbContext
    {
        public StudentContext() : base("StudentContext") { }
        public DbSet<Student> Students { get; set; }
    }
}