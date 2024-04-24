using Microsoft.EntityFrameworkCore;
using EvaStudent.Models;
using EvaStudents.Models;

namespace EvaStudents.Data

{
    public class StuDbContext: DbContext
    {
        public StuDbContext(DbContextOptions<StuDbContext>options) : base(options)
        {
            
        }
        public DbSet<StudentDtails> StudentDtails { get; set; }
        public DbSet<StudentMarkSheet> StudentMarkSheet { get; set;}
    }
}
