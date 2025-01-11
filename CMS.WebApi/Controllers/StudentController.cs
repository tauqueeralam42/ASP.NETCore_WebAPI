using CMS.WebApi.Data;
using CMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly CollegeContext _context;

        public StudentsController(CollegeContext context)
        {
            _context = context;
        }

        // GET: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // POST: api/students
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent([FromForm] StudentDto studentDto)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                firstName = studentDto.firstName,
                lastName = studentDto.lastName,
                email = studentDto.email,
                age = studentDto.age
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        // PUT: api/students/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(Guid id, [FromForm] StudentDto updateStudentDto)
        {
            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.firstName = updateStudentDto.firstName;
            existingStudent.lastName = updateStudentDto.lastName;
            existingStudent.email = updateStudentDto.email;
            existingStudent.age = updateStudentDto.age;

            _context.Entry(existingStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        private bool StudentExists(Guid id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

    }


}
