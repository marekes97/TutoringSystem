using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext dbContext;

        public SubjectRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<Subject> GetSubjects() => dbContext.Subjects
            .Include(s => s.Reservations)
            .Include(s => s.Tutor)
            .ToList();

        public Subject GetSubject(int id) => GetSubjects()
            .FirstOrDefault(s => s.Id.Equals(id));

        public Subject GetSubject(string name) => GetSubjects()
            .FirstOrDefault(s => s.Name.Equals(name));

        public Subject GetSubject(Reservation reservation) => GetSubjects()
            .FirstOrDefault(s => s.Reservations.FirstOrDefault(r => r.Id.Equals(reservation.Id)) != null);
    }
}
