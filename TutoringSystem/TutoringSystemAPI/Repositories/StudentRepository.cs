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

        public void UpdateStudent(Student student)
        {
            dbContext.Students.Update(student);
            dbContext.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            dbContext.Remove(student);
            dbContext.SaveChanges();
        }
    }
}
