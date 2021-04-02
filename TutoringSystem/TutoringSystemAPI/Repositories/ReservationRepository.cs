using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext dbContext;
        private readonly ILessonRepository lessonRepo;
        private readonly IStudentRepository studentRepo;
        private readonly ITutorRepository tutorRepo;
        private readonly ISubjectRepository subjectRepo;

        public ReservationRepository(AppDbContext dbContext, 
            ILessonRepository lessonRepo, 
            IStudentRepository studentRepo, 
            ITutorRepository tutorRepo, 
            ISubjectRepository subjectRepo)
        {
            this.dbContext = dbContext;
            this.lessonRepo = lessonRepo;
            this.studentRepo = studentRepo;
            this.tutorRepo = tutorRepo;
            this.subjectRepo = subjectRepo;
        }

        public ICollection<Reservation> GetStudentReservations(string userName)
        {
            var user = studentRepo.GetStudent(userName);
            var reservation = dbContext.Reservations.Where(r => r.Student.Equals(user)).ToList();
            reservation.ForEach(r => r.Lesson = lessonRepo.GetLesson(r));
            return reservation;
        }

        public ICollection<Reservation> GetTutorReservations(string userName)
        {
            var tutor = tutorRepo.GetTutor(userName);
            // var reservation = dbContext.Reservations.Where(r => r.TutorId.Equals(tutor.Id)).ToList();
            var reservation = dbContext.Reservations
                .Include(r => r.Lesson)
                .Include(r => r.Subject)
                .Include(r => r.Student)
                .Include(r => r.Tutor)
                .Where(r => r.Tutor.Equals(tutor)).ToList();
            // reservation.ForEach(r => r.Lesson = lessonRepo.GetLesson(r));
            return reservation;
        }

        public Reservation GetStudentReservation(int id, string userName)
        {
            var userReservation = GetStudentReservations(userName);
            var reservation = userReservation?.FirstOrDefault(r => r.Id.Equals(id));
            if (reservation != null)
            {
                reservation.Student = studentRepo.GetStudent(userName);
                reservation.Subject = subjectRepo.GetSubject(reservation);
                reservation.Tutor = tutorRepo.GetTutor(reservation);
                return reservation;
            }
            return null;
        }

        public Reservation GetTutorReservation(int id, string userName)
        {
            var userReservation = GetTutorReservations(userName);
            var reservation = userReservation?.FirstOrDefault(r => r.Id.Equals(id));
            return reservation;
        }

        public void AddTutorReservation(Reservation reservation, string studentName)
        {
            var subject = dbContext.Subjects.FirstOrDefault(s => s.Name.Equals(reservation.Subject.Name));
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
