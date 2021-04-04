using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IStudentRepository studentRepo;
        private readonly ITutorRepository tutorRepo;
        private readonly ISubjectRepository subjectRepo;

        public ReservationRepository(AppDbContext dbContext, 
            IStudentRepository studentRepo, 
            ITutorRepository tutorRepo, 
            ISubjectRepository subjectRepo)
        {
            this.dbContext = dbContext;
            this.studentRepo = studentRepo;
            this.tutorRepo = tutorRepo;
            this.subjectRepo = subjectRepo;
        }

        public ICollection<Reservation> GetReservations() => dbContext.Reservations
            .Include(r => r.Lesson)
            .Include(r => r.Subject)
            .Include(r => r.Student)
            .Include(r => r.Tutor)
            .ToList();

        public ICollection<Reservation> GetStudentReservations(string userName)
        {
            var student = studentRepo.GetStudent(userName);
            var reservation = GetReservations()
                .Where(r => r.Student.Equals(student)).ToList();

            return reservation;
        }

        public ICollection<Reservation> GetTutorReservations(string userName)
        {
            var tutor = tutorRepo.GetTutor(userName);
            var reservation = GetReservations()
                .Where(r => r.Tutor.Equals(tutor)).ToList();

            return reservation;
        }

        public Reservation GetStudentReservation(int id, string userName)
        {
            var userReservation = GetStudentReservations(userName);
            var reservation = userReservation?.FirstOrDefault(r => r.Id.Equals(id));
            return reservation;
        }

        public Reservation GetTutorReservation(int id, string userName)
        {
            var userReservation = GetTutorReservations(userName);
            var reservation = userReservation?.FirstOrDefault(r => r.Id.Equals(id));
            return reservation;
        }

        public void AddTutorReservation(Reservation reservation, string subjectName, string studentName)
        {
            var subject = subjectRepo.GetSubject(subjectName);
            var student = dbContext.Students.FirstOrDefault(s => s.UserName.Equals(studentName));
            reservation.Student = student;
            reservation.Subject = subject;

            var cost = student.HourlRate * reservation.Lesson.Duration;
            reservation.Cost = cost;

            dbContext.Reservations.Add(reservation);
            dbContext.SaveChanges();
        }
    }
}
