using CMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.WebApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public static List<Student> Students = new List<Student>
        {
            new Student{ id = 1, firstName = "John", lastName = "Doe", age = 20 },
            new Student{ id = 2, firstName = "Jane", lastName = "Doe", age = 21 },
            new Student{ id = 3, firstName = "James", lastName = "Smith", age = 22 }
        };

        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            return Ok(Students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = Students.FirstOrDefault(s => s.id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> AddStudent([FromBody] Student student)
        {
            student.id = Students.Count + 1;
            Students.Add(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.id }, student);

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = Students.FirstOrDefault(s => s.id == id);
            if (student == null)
            {
                return NotFound();
            }
            Students.Remove(student);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Student> UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = Students.FirstOrDefault(s => s.id == id);
            if (student == null)
            {
                return NotFound();
            }
            student.id = updatedStudent.id;
            student.firstName = updatedStudent.firstName;
            student.lastName = updatedStudent.lastName;
            student.age = updatedStudent.age;

            return Ok(student);
        }
    }
}
