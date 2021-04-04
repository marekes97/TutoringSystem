using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public ICollection<Tutor> GetTutors() => dbContext.Tutors
            .Include(t => t.AdditionalOrders)
            .Include(t => t.Address)
            .Include(t => t.Availabilities)
            .Include(t => t.Contact)
            .Include(t => t.Reservations)
            .Include(t => t.Subjects)
            .ToList();

        public Tutor GetTutor(string userName) => GetTutors()
                .FirstOrDefault(t => t.UserName.Equals(userName));

        public Tutor GetTutor(Reservation reservation) => GetTutors()
                .FirstOrDefault(t => t.Reservations.FirstOrDefault(r => r.Equals(reservation)) != null);

        public void CreateTutor(Tutor tutor)
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
