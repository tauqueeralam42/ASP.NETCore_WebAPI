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

        // GET: api/students/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
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
        public async Task<ActionResult<Student>> AddStudent([FromBody] Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudent), new { id = student.id }, student);
        }

        // DELETE: api/students/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/students/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            if (id != updatedStudent.id)
            {
                return BadRequest();
            }

            _context.Entry(updatedStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Students.Any(e => e.id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // PATCH: api/students/1
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(updatedStudent.firstName))
            {
                student.firstName = updatedStudent.firstName;
            }
            if (!string.IsNullOrEmpty(updatedStudent.lastName))
            {
                student.lastName = updatedStudent.lastName;
            }
            if (updatedStudent.age > 0)
            {
                student.age = updatedStudent.age;
            }

            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}
