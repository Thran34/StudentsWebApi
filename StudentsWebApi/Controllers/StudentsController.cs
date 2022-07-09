using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsWebApi.Domain.Model;
using StudentsWebApi.Infrastructure.Context;

namespace StudentsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyAllowSpecificOrigins")]
    public class StudentsController : ControllerBase
    {
        private readonly DBContext _context;

        public StudentsController(DBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all students from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _context.Students.Include(x => x.Teacher).Include(x => x.StudentFullName).Include(x => x.Lesson).ToListAsync();

        }

        /// <summary>
        /// Get student by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            var student = await _context.Students.Include(x => x.Teacher)
                .Include(x => x.Lesson).FirstAsync(p => p.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        /// <summary>
        /// Edit student by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

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
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        /// <summary>
        /// Add new student to database
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent([FromBody] Student student)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'DBContext.Students'  is null.");
            }
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        /// <summary>
        /// Delete student by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            var student = await _context.Students.Include(x => x.Teacher)
                .Include(x => x.Lesson).FirstAsync(p => p.Id == id);
            var teacher = await _context.Teachers.FirstAsync(k => k.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
