using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaStudents.Models
{
    public class StudentMarkSheet
    {
        [Key]
        public int MarkSheetId { get; set; }
        [ForeignKey("StudentId")]
        public int StudentRefId { get; set; }
        public int SubjectTotalMark { get; set; }
        public int MarksObtained { get; set; }

       // public required StudentDetails StudentDetails { get; set; }
    }
}
