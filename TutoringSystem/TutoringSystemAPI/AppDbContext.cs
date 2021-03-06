﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI
{
    public class AppDbContext : DbContext
    {
        private readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Database=TutoringSystemDb;Trusted_Connection=True;";

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Tutor> Tutors { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public virtual DbSet<AdditionalOrder> AdditionalOrders { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Availability> Availabilities { get; set; }
        public virtual DbSet<Interval> Intervals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Tutor>().ToTable("Tutors");

            modelBuilder.Entity<Subject>().HasOne(s => s.Tutor).WithMany(t => t.Subjects)
                   .HasForeignKey(s => s.TutorId)
                    .OnDelete(DeleteBehavior.NoAction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
