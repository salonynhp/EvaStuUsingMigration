using System.ComponentModel.DataAnnotations;

namespace EvaStudent.Models
{
    public class StudentDtails
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public required string StudentName { get; set; }
        [Required]
        public DateTime StudentJoinDate { get; set; }
        [Required]
        public required string Class { get; set; }
        public int TotalMarkObtained { get; set; }
        public double TotalPercentage { get; set; }

        // public ICollection<StudentMarkSheet> StudentMarkSheet{ get; set; }   

    }
}
