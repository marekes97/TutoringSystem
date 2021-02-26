using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemAPI.Repositories;
using TutoringSystemLib.Entities;
using TutoringSystemLib.Models;

namespace TutoringSystemAPI.Controllers
{
    [Route("api/student")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository students;
        private readonly IMapper mapper;
        private readonly IPasswordHasher<User> passwordHasher;

        public StudentController(IStudentRepository students, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            this.students = students;
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
        }

        [HttpGet]
        [Authorize(Roles = "Tutor")]
        public ActionResult<List<StudentDto>> Get()
        {
            var studentsDtos = mapper.Map<List<StudentDto>>(students.GetStudents());
            return Ok(studentsDtos);
        }

        [HttpGet("{userName}")]
        [Authorize(Roles = "Tutor")]
        public ActionResult<StudentDto> Get(string userName)
        {
            var student = students.GetStudent(userName);
            if (student == null)
                return NotFound();

            var studentDto = mapper.Map<StudentDetailsDto>(student);
            return Ok(studentDto);
        }

        [HttpPut("{userName}")]
        [Authorize(Roles = "Tutor")]
        public ActionResult Put(string userName, [FromBody] RegisterUserDto userDto)
        {
            var student = students.GetStudent(userName);
            if (student == null)
                return NotFound();

            var newStudent = mapper.Map<Student>(userDto);
            newStudent.PasswordHash = passwordHasher.HashPassword(newStudent, userDto.Password);
            students.UpdateStudent(userName, newStudent);

            return NoContent();
        }

        [HttpDelete("{userName}")]
        [Authorize(Roles = "Tutor")]
        public ActionResult Delete(string userName)
        {
            var student = students.GetStudent(userName);
            if (student == null)
                return NotFound();

            students.DeleteStudent(student);
            return NoContent();
        }
    }
}
