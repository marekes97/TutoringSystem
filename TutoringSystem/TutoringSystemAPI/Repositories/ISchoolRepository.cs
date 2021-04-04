using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface ISchoolRepository
    {
        School GetSchool(int id);
        School GetSchool(Student student);
        ICollection<School> GetSchools();
        void UpdateSchool(School oldSchool, School newSchool);
    }
}