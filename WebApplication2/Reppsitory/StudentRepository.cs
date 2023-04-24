using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Reppsitory
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();

        public List<Student> GetStudents()
        {
            return students;
        }
        public int AddStudent(Student student)
        {
            student.Id = students.Count + 1;
            students.Add(student);
            return student.Id;
        }
    }
}
