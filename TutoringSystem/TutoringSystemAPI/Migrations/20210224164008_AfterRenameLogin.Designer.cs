﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TutoringSystemAPI;

namespace TutoringSystemAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210224164008_AfterRenameLogin")]
    partial class AfterRenameLogin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TutoringSystemLib.Entities.AdditionalOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("AdditionalOrders");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiscordName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Duration")
                        .HasColumnType("float");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId")
                        .IsUnique();

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<int>("Place")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TutorId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EducationLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("HourlRate")
                        .HasColumnType("float");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LessonId")
                        .IsUnique();

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Student", b =>
                {
                    b.HasBaseType("TutoringSystemLib.Entities.User");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Tutor", b =>
                {
                    b.HasBaseType("TutoringSystemLib.Entities.User");

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.AdditionalOrder", b =>
                {
                    b.HasOne("TutoringSystemLib.Entities.Tutor", "Tutor")
                        .WithMany("AdditionalOrders")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Address", b =>
                {
                    b.HasOne("TutoringSystemLib.Entities.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("TutoringSystemLib.Entities.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Contact", b =>
                {
                    b.HasOne("TutoringSystemLib.Entities.User", "User")
                        .WithOne("Contact")
                        .HasForeignKey("TutoringSystemLib.Entities.Contact", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Lesson", b =>
                {
                    b.HasOne("TutoringSystemLib.Entities.Reservation", "Reservation")
                        .WithOne("Lesson")
                        .HasForeignKey("TutoringSystemLib.Entities.Lesson", "ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.PhoneNumber", b =>
                {
                    b.HasOne("TutoringSystemLib.Entities.Contact", "Contact")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Reservation", b =>
                {
                    b.HasOne("TutoringSystemLib.Entities.Student", "Student")
                        .WithMany("Reservations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TutoringSystemLib.Entities.Tutor", "Tutor")
                        .WithMany("Reservations")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.School", b =>
                {
                    b.HasOne("TutoringSystemLib.Entities.Student", "Student")
                        .WithOne("School")
                        .HasForeignKey("TutoringSystemLib.Entities.School", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Subject", b =>
                {
                    b.HasOne("TutoringSystemLib.Entities.Lesson", "Lesson")
                        .WithOne("Subject")
                        .HasForeignKey("TutoringSystemLib.Entities.Subject", "LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Student", b =>
                {
                    b.HasOne("TutoringSystemLib.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("TutoringSystemLib.Entities.Student", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Tutor", b =>
                {
                    b.HasOne("TutoringSystemLib.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("TutoringSystemLib.Entities.Tutor", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Contact", b =>
                {
                    b.Navigation("PhoneNumbers");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Lesson", b =>
                {
                    b.Navigation("Subject");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Reservation", b =>
                {
                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.User", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Student", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("School");
                });

            modelBuilder.Entity("TutoringSystemLib.Entities.Tutor", b =>
                {
                    b.Navigation("AdditionalOrders");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
