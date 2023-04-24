using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Datadto;
using WebApplication2.Model;

namespace WebApplication2.Reppsitory
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDBContext _context;
        private readonly ILogger<Employee> _log;

        public EmployeeService(EmployeeDBContext context, ILogger<Employee> log)
        {
            _context = context;
            _log = log;
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                List<Employee> employees = _context.Employees.ToList();
                return employees;
            }
            catch
            {
                return null;
            }
        }

        public Employee GetEmployeebyId(int id)
        {
            try
            {
                return _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
            }
            catch
            {
                return null;
            }
        }

        #region "Add Employees"
        public Employee AddEmployees(Employee employees)
        {
            try
            {
                /*var employee = new Employee
                {
                    Name = employees.Name,
                    Address = employees.Address,
                    City = employees.City,
                    Pan = employees.Pan
                };*/
                _context.Employees.Add(employees);
                _context.SaveChanges();
                return employees;
            }
            catch (Exception error)
            {
                _log.LogError(error.Message);
            }
            return null;
        }
        #endregion

        #region "Update EmployeeDetails"
        public Employee UpdateEmployees(Employee dto)
        {
            var result = _context.Employees.FirstOrDefault(e => e.EmployeeID == dto.EmployeeID);
            try
            {
                if (result != null)
                {
                    result.Name = dto.Name;
                    result.Address = dto.Address;
                    result.City = dto.City;
                    result.Pan = dto.Pan;
                    _context.Entry(result).State = EntityState.Modified;
                    _context.SaveChanges();
                    return result;
                }
            }
            
            //employee.EmployeeID = dto.EmployeeId;
            
            catch (Exception error)
            {
                _log.LogError(error.Message);
            }
            return null;
        }
        #endregion

        #region "Remove/Delete Employees"
        public Employee RemoveEmployee(int id)
        {
            try
            {
                var result = _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
                _context.Employees.Remove(result);
                _context.SaveChanges();
                return result;
            }
            catch (Exception error)
            {
                _log.LogError(error.Message);
            }
            return null;
        }
        #endregion

        #region "Update Employees Partially"
        public void UpdateEmployeePatch(JsonPatchDocument employee, int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp != null)
            {
                employee.ApplyTo(emp);
                _context.SaveChanges();
            }
        }
        #endregion
    }
}
