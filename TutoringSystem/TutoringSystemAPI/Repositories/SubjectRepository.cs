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

        public ICollection<Subject> GetSubjects() => dbContext.Subjects.ToList();

        public Subject GetSubject(int id) => dbContext.Subjects.FirstOrDefault(s => s.Id.Equals(id));

        public Subject GetSubject(string name) => dbContext.Subjects.FirstOrDefault(s => s.Name.Equals(name));

        public Subject GetSubject(Reservation reservation) => dbContext.Subjects
            .FirstOrDefault(s => s.Reservations.FirstOrDefault(r => r.Id.Equals(reservation.Id)) != null);
    }
}
