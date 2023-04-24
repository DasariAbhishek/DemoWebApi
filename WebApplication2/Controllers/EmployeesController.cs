using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Datadto;
using WebApplication2.Model;
using WebApplication2.Reppsitory;

namespace WebApplication2.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : Controller
    {
        //private readonly EmployeeDBContext _context;
        private readonly IEmployeeService _repo;

        public EmployeesController(IEmployeeService repo)
        {
            _repo = repo;
        }

        // GET: api/Employees
        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            List<Employee> emp = _repo.GetAllEmployees();
            if(emp.Count > 0)
            {
                return Ok(emp);
            }
            return NotFound(new { msg = "No Employees Found" });
        }

        // GET: api/Employees/5
        [HttpGet("GetEmployee/{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _repo.GetEmployeebyId(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("UpdateEmployee/{id:int}")]
        public IActionResult PutEmployee([FromRoute]int id,Employee dto)
        {
            if (ModelState.IsValid)
            {
                if (id != dto.EmployeeID)
                    return BadRequest("EmployeeId is mismatch");

                var employeeToUpdate = _repo.GetEmployeebyId(id);

                if (employeeToUpdate == null)
                    return NotFound($"Employee with Id = {id} not found");

                Employee emp = _repo.UpdateEmployees(dto);
               /* if(emp == null)
                {
                    return NotFound(new { msg = "No Employees Found" });
                }*/
                return Ok(emp);
            }

            /*_context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }*/
            return ValidationProblem("Fill the data Properly...");
            //return NoContent();
        }

        // POST: api/Employees
        [HttpPost("AddEmployees")]
        public ActionResult<Employee> PostEmployee([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                
                if (employee == null)
                {
                    return BadRequest(new { msg = "Some errors happens ... TryAgain" });
                }
                var emp = _repo.AddEmployees(employee);
                return CreatedAtAction(nameof(PostEmployee), new { id = emp.EmployeeID }, emp);
            }
            return ValidationProblem("Fill the data Properly...");

        }

        // PATCH: api/Employee/3
        [HttpPatch("{id}")]
        public IActionResult PatchEmployee([FromRoute] int id,[FromBody] JsonPatchDocument employee)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateEmployeePatch(employee, id);
                if (employee == null)
                {
                    return NotFound(new { msg = "No Employees Found" });
                }
                return Ok();
            }
            return ValidationProblem("Fill the data Properly...");
        }

        // DELETE: api/Employees/5
        [HttpDelete("RemoveEmployee/{id}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            var employee = _repo.RemoveEmployee(id);
            if (employee == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            return Ok(employee);
        }

        /*private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }*/
    }
}
