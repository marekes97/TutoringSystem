using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class TutorRepository : ITutorRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IPasswordHasher<User> passwordHasher;

        public TutorRepository(AppDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
        }

        public Tutor GetTutor(string userName)
        {
            return dbContext.Tutors
                .FirstOrDefault(t => t.UserName.Equals(userName));
        }

        public ICollection<Tutor> GetTutors() => dbContext.Tutors.ToList();

        public void AddTutor(Tutor tutor)
        {
            dbContext.Tutors.Add(tutor);
            dbContext.SaveChanges();
        }

        public void UpdateTutor(string userName, Tutor newTutor)
        {
            var tutor = GetTutor(userName);


        }

        public void ChangePassword(string userName, string password)
        {
            var tutor = GetTutor(userName);

            var passwordHash = passwordHasher.HashPassword(tutor, password);
            tutor.PasswordHash = passwordHash;
            dbContext.Tutors.Update(tutor);
            dbContext.SaveChanges();
        }

        public void DeleteTutor(string userName)
        {
            var tutor = GetTutor(userName);

            dbContext.Users.Remove(tutor);
            dbContext.SaveChanges();
        }
    }
}
