using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly AppDbContext dbContext;

        public SchoolRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<School> GetSchools() => dbContext.Schools
            .Include(s => s.Student)
            .ToList();

        public School GetSchool(int id) => dbContext.Schools
            .Include(s => s.Student)
            .FirstOrDefault(s => s.Id.Equals(id));

        public School GetSchool(Student student) => dbContext.Schools
            .Include(s => s.Student)
            .FirstOrDefault(s => s.Student.Equals(student));


        public void UpdateSchool(School oldSchool, School newSchool)
        {
            oldSchool.EducationLevel = newSchool.EducationLevel;
            oldSchool.Name = newSchool.Name;
            oldSchool.Year = newSchool.Year;

            dbContext.Schools.Update(oldSchool);
            dbContext.SaveChanges();
        }
    }
}
