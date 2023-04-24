using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Datadto;
using WebApplication2.Model;

namespace WebApplication2.Reppsitory
{
    public interface IEmployeeService
    {
        Employee AddEmployees(Employee employees);
        List<Employee> GetAllEmployees();

        Employee GetEmployeebyId(int id);
        Employee RemoveEmployee(int id);
        void UpdateEmployeePatch(JsonPatchDocument employee, int id);
        Employee UpdateEmployees(Employee dto);
    }
}