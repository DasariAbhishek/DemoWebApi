using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;
using WebApplication2.Reppsitory;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            _repo.AddStudent(student);
            var students = _repo.GetStudents();

            return Ok(students);
        }
    }
}
