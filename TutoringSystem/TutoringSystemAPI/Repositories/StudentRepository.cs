using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly IAddressRepository addressRepo;
        private readonly ISchoolRepository schoolRepo;
        private readonly IContactRepository contactRepo;

        public StudentRepository(AppDbContext dbContext,
            IPasswordHasher<User> passwordHasher,
            IAddressRepository addressRepo,
            ISchoolRepository schoolRepo, 
            IContactRepository contactRepo)
        {
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
            this.addressRepo = addressRepo;
            this.schoolRepo = schoolRepo;
            this.contactRepo = contactRepo;
        }

        public ICollection<Student> GetStudents() => dbContext.Students
            .Include(s => s.Address)
            .Include(s => s.Contact)
            .Include(s => s.Reservations)
            .Include(s=> s.School)
            .ToList();

        public Student GetStudent(string userName) => GetStudents()
                .FirstOrDefault(s => s.UserName.Replace(" ", "-").ToLower().Equals(userName.ToLower()));
        
        public Student GetStudent(Reservation reservation) => GetStudents()
                .FirstOrDefault(s => s.Reservations.Equals(reservation));

        public void CreateStudent(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }

        public void UpdateStudent(string userName, Student newStudent)
        {
            var student = GetStudent(userName);

            addressRepo.UpdateAddress(student.Address, newStudent.Address);
            schoolRepo.UpdateSchool(student.School, newStudent.School);
            contactRepo.UpdateContact(student.Contact, newStudent.Contact);

            student.FirstName = newStudent.FirstName;
            student.LastName = newStudent.LastName;
            student.UserName = newStudent.UserName;

            dbContext.Students.Update(student);
            dbContext.SaveChanges();
        }

        public void ChangePassword(string userName, string password)
        {
            var student = GetStudent(userName);

            var passwordHash = passwordHasher.HashPassword(student, password);
            student.PasswordHash = passwordHash;

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
