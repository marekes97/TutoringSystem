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
            var address = dbContext.Addresses.FirstOrDefault(a => a.User.Equals(student));
            var contact = dbContext.Contacts.FirstOrDefault(c => c.User.Equals(student));
            var school = dbContext.Schools.FirstOrDefault(s => s.Student.Equals(student));
            var phones = dbContext.PhoneNumbers.Where(p => p.Contact.Equals(contact)).ToList();

            address.City = newStudent.Address.City;
            address.PostalCode = newStudent.Address.PostalCode;
            address.Street = newStudent.Address.Street;

            contact.DiscordName = newStudent.Contact.DiscordName;
            contact.Email = newStudent.Contact.Email;
            for (int i = 0; i < phones.Count; i++)
            {
                phones[i].Number = newStudent.Contact.PhoneNumbers[i].Number;
                phones[i].Owner = newStudent.Contact.PhoneNumbers[i].Owner;
            }
            if(newStudent.Contact.PhoneNumbers.Count > phones.Count)
            {
                for (int i = phones.Count; i < newStudent.Contact.PhoneNumbers.Count; i++)
                {
                    phones[i].Number = newStudent.Contact.PhoneNumbers[i].Number;
                    phones[i].Owner = newStudent.Contact.PhoneNumbers[i].Owner;
                }
            }

            school.EducationLevel = newStudent.School.EducationLevel;
            school.Name = newStudent.School.Name;
            school.Year = newStudent.School.Year;

            student.FirstName = newStudent.FirstName;
            student.LastName = newStudent.LastName;
            student.PhotoUrl = newStudent.PhotoUrl;
            student.PasswordHash = newStudent.PasswordHash;
            student.UserName = newStudent.UserName;

            dbContext.Students.Update(student);
            dbContext.Addresses.Update(address);
            dbContext.Contacts.Update(contact);
            dbContext.Schools.Update(school);

            dbContext.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            dbContext.Remove(student);
            dbContext.SaveChanges();
        }
    }
}
