using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI
{
    public class Seeder
    {
        private readonly AppDbContext dbContext;
        private readonly IPasswordHasher<User> passwordHasher;

        public Seeder(AppDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
        }

        public void Seed()
        {
            if (!dbContext.Users.Any())
                InsertSampleData();
        }

        private void InsertSampleData()
        {
            var orders = new List<AdditionalOrder>
            {
                new AdditionalOrder
                {
                    Name = "Projekt C++ Terminarz",
                    Cost = 300.0,
                    Deadline = new DateTime(2021, 02, 01),
                    Description = "Projekt programistyczny dotyczący stworzenia bazodanowego projektu okienkowego \"Terminarz\""
                },
                new AdditionalOrder
                {
                    Name = "Projekt C# Biuro matrymonialne",
                    Cost = 150.0,
                    Deadline = new DateTime(2021, 02, 16),
                    Description = "Projekt programistyczny mający na celu stworzenie aplikacji do obsługi biura matrymonialnego"
                }
            };

            var programming = new Lesson
            {
                Subject = new Subject
                {
                    Name = "Programowanie",
                    HourlRate = 50.0
                },
                Description = "Omówienie tablic w języku C++",
                Duration = 2.0,
            };

            var math = new Lesson
            {
                Subject = new Subject
                {
                    Name = "Matematyka",
                    HourlRate = 40.0
                },
                Description = "Ciągi arytmetyczne",
                Duration = 1.5,
            };

            var me = new User
            {
                AdditionalOrders = orders,

                Contact = new Contact
                {
                    DiscordName = "marekes99#3923",
                    Email = "marekes97@gmail.com",
                    PhoneNumbers = new List<PhoneNumber>
                    {
                        new PhoneNumber
                        {
                            Owner = "Me",
                            Number = "536599019"
                        }
                    }
                },
                Address = new Address
                {
                    Street = "Ratowników Górniczych 1/6",
                    City = "Gliwice",
                    PostalCode = "44-100"
                },

                Role = Role.Tutor,
                FirstName = "Marek",
                LastName = "Sroczkowski",
                Login = "Admin"
            };
            me.PasswordHash = passwordHasher.HashPassword(me, "1234");

            var bartoszDras = new User
            {
                FirstName = "Bartosz",
                LastName = "Dras",
                Login = "BarDra",
                Role = Role.Student,
                Contact = new Contact
                {
                    PhoneNumbers = new List<PhoneNumber>
                    {
                        new PhoneNumber
                        {
                            Owner = "Mama Bartka",
                            Number = "505953774"
                        }
                    }
                },
                School = new School
                {
                    EducationLevel = EducationLevel.HighSchool,
                    Year = 2,
                }
            };
            bartoszDras.PasswordHash = passwordHasher.HashPassword(bartoszDras, "1234");

            var alicjaSzmigiel = new User
            {
                FirstName = "Alicja",
                LastName = "Szmigiel",
                Login = "AliSzm",
                Role = Role.Student,
                Contact = new Contact
                {
                    DiscordName = "ala#0559"
                },
                School = new School
                {
                    EducationLevel = EducationLevel.HighSchool,
                    Year = 2,
                }
            };
            alicjaSzmigiel.PasswordHash = passwordHasher.HashPassword(alicjaSzmigiel, "1234");

            var r1 = new Reservation
            {
                StartTime = new DateTime(2021, 02, 22),
                Lesson = math,
                Cost = math.Duration * math.Subject.HourlRate,
                Student = bartoszDras,
                Tutor = me,
                Place = Place.AtTutor
            };
            var r2 = new Reservation
            {
                StartTime = new DateTime(2021, 02, 22),
                Lesson = programming,
                Cost = programming.Duration * programming.Subject.HourlRate,
                Student = alicjaSzmigiel,
                Tutor = me,
                Place = Place.Online
            };

            me.Reservations.Add(r1);
            me.Reservations.Add(r2);

            bartoszDras.Reservations.Add(r1);
            alicjaSzmigiel.Reservations.Add(r2);

            dbContext.Users.Add(me);
            dbContext.Users.Add(bartoszDras);
            dbContext.Users.Add(alicjaSzmigiel);

            dbContext.SaveChanges();
        }
    }
}
