using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<Student> GetStudents() => dbContext.Students.ToList();

        public Student GetStudent(string userName)
        {
            return dbContext.Students
                .FirstOrDefault(m => m.UserName.Replace(" ", "-").ToLower().Equals(userName.ToLower()));
        }

        public void CreateStudent(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }

        public void UpdateStudent(string userName, Student newStudent)
        {
            var student = GetStudent(userName);
            student.Address = newStudent.Address;
            student.Contact = newStudent.Contact;
            student.FirstName = newStudent.FirstName;
            student.LastName = newStudent.LastName;
            student.PhotoUrl = newStudent.PhotoUrl;
            student.PasswordHash = newStudent.PasswordHash;
            student.School = newStudent.School;
            student.UserName = newStudent.UserName;

            dbContext.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            dbContext.Remove(student);
            dbContext.SaveChanges();
        }
    }
}
