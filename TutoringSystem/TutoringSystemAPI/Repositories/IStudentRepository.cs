using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface IStudentRepository
    {
        void ChangePassword(string userName, string password);
        void CreateStudent(Student student);
        void DeleteStudent(Student student);
        Student GetStudent(string userName);
        Student GetStudent(Reservation reservation);
        ICollection<Student> GetStudents();
        void UpdateStudent(string userName, Student newStudent);
    }
}