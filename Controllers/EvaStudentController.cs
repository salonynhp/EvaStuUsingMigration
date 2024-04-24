using Microsoft.AspNetCore.Mvc;
using EvaStudents.Models;
using EvaStudent.Business;
using EvaStudents.Data;
using EvaStudent.Models;
namespace EvaStudents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaStudentController : Controller
    {

        private readonly StuDbContext _context;

        public object GetStudentById { get; private set; }
        public object GetMarkSheetById { get; private set; }

        public EvaStudentController(StuDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetTotalMarkObtained")]
        public int GetTotalMarkObtained(int studentId)
        {
            var markSheets = _context.StudentMarkSheet.Where(ms => ms.StudentRefId == studentId);
            return markSheets.Sum(ms => ms.MarksObtained);
        }


        [HttpGet("GetTotalPercentageObtained")]
        public double GetTotalPercentageObtained(int studentId)
        {
            var markSheets = _context.StudentMarkSheet.Where(ms => ms.StudentRefId == studentId);
            var totalMarks = markSheets.Sum(ms => ms.SubjectTotalMark);
            var marksObtained = markSheets.Sum(ms => ms.MarksObtained);
            return (double)marksObtained / totalMarks * 100;
        }
        [HttpGet("GetAllMarksById")]
        public IEnumerable<StudentMarkSheet> GetAllMarksById(int studentId)
        {
            return _context.StudentMarkSheet.Where(ms => ms.StudentRefId == studentId);
        }
        [HttpPost("AddMarks")]
        public IActionResult AddMarks(StudentMarkSheet markSheet)
        {
            _context.StudentMarkSheet.Add(markSheet);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("UpdateMarks")]
        public IActionResult UpdateMarks(StudentMarkSheet markSheet)
        {
            var existingMarkSheet = _context.StudentMarkSheet.Find(markSheet.MarkSheetId);
            if (existingMarkSheet != null)
            {
                existingMarkSheet.SubjectTotalMark = markSheet.SubjectTotalMark;
                existingMarkSheet.MarksObtained = markSheet.MarksObtained;
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        [HttpGet("GetStudentList")]
        public IEnumerable<StudentDtails> GetStudentList()
        {
            var students = _context.StudentDtails.ToList();
            foreach (var student in students)
            {
                student.TotalMarkObtained = GetTotalMarkObtained(student.StudentId);
                student.TotalPercentage = GetTotalPercentageObtained(student.StudentId);
            }
            return students;
        }
        [HttpPost("AddStudent")]
        public IActionResult AddStudent([FromBody] StudentDtails student)
        {
            if (ModelState.IsValid)
            {
                _context.StudentDtails.Add(student);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentId }, student);
            }
            return BadRequest(ModelState);
        }
        [HttpPost("AddMarkSheet")]
        public IActionResult AddMarkSheet([FromBody] StudentMarkSheet markSheet)
        {
            if (ModelState.IsValid)
            {
                _context.StudentMarkSheet.Add(markSheet);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetMarkSheetById), new { id = markSheet.MarkSheetId }, markSheet);
            }
            return BadRequest(ModelState);
        }

    }
}
