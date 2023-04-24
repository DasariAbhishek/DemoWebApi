using System.Collections.Generic;
using WebApplication2.Model;

namespace WebApplication2.Reppsitory
{
    public interface IStudentRepository
    {
        int AddStudent(Student student);
        List<Student> GetStudents();
    }
}