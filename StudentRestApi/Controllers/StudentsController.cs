using Microsoft.AspNetCore.Mvc;
using StudentRestApi.Models;
using Microsoft.AspNetCore.Http;
namespace StudentRestApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Student>>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await studentRepository.Search(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }
                ;
                return NotFound();
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                return Ok(await studentRepository.GetStudents());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");


            }
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var result = await studentRepository.GetStudent(id);
                if (result == null)
                {
                    return NotFound();

                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
                }
                var stu = await studentRepository.GetStudentByEmail(student.Email);

                if (stu != null)
                {
                    ModelState.AddModelError("Email", "Student email already in use");
                    return BadRequest(ModelState);
                }
                var createdStudent = await studentRepository.AddStudent(student);

                return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.StudentId }, createdStudent);


            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creatin Student");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
            try
            {
                if(id != student.StudentId)
                {
                    return BadRequest("Student Id mismatch");
                }

                var studentToUpdate = await studentRepository.GetStudent(id);

                if (studentToUpdate == null)
                {
                    return NotFound($"Student id={id} is not found");
                    
                }
                return await studentRepository.UpdateStudent(studentToUpdate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                var studentToDelete = await studentRepository.GetStudent(id);
                if (studentToDelete == null)
                {
                    return NotFound($"Student id={id} is not found");
                }
                await studentRepository.DeleteStudent(id);
                return Ok("Student is deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
    }
}
