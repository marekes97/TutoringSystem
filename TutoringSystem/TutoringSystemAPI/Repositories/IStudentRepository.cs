using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface IStudentRepository
    {
        void CreateStudent(Student student);
        void DeleteStudent(Student student);
        Student GetStudent(string userName);
        ICollection<Student> GetStudents();
        void UpdateStudent(Student student);
    }
}