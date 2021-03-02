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
        private readonly IStudentRepository studentRepo;
        private readonly IMapper mapper;

        public StudentController(IStudentRepository studentRepo, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            this.studentRepo = studentRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Tutor")]
        public ActionResult<List<UserDto>> Get()
        {
            var studentsDtos = mapper.Map<List<UserDto>>(studentRepo.GetStudents());
            return Ok(studentsDtos);
        }

        [HttpGet("{userName}")]
        [Authorize(Roles = "Tutor")]
        public ActionResult<UserDto> Get(string userName)
        {
            var student = studentRepo.GetStudent(userName);
            if (student == null)
                return NotFound();

            var studentDto = mapper.Map<StudentDetailsDto>(student);
            return Ok(studentDto);
        }

        [HttpPut("{userName}")]
        [Authorize(Roles = "Tutor, Student")]
        public ActionResult Put(string userName, [FromBody] RegisterUserDto userDto)
        {
            var student = studentRepo.GetStudent(userName);
            if (student == null)
                return NotFound();

            var newStudent = mapper.Map<Student>(userDto);
            studentRepo.ChangePassword(userName, userDto.Password);
            studentRepo.UpdateStudent(userName, newStudent);

            return NoContent();
        }

        [HttpPatch("{userName}")]
        [Authorize(Roles = "Tutor, Student")]
        public ActionResult Patch(string userName, [FromBody] PasswordDto passwordDto)
        {
            var student = studentRepo.GetStudent(userName);
            if (student == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            studentRepo.ChangePassword(userName, passwordDto.NewPassword);
            return NoContent();
        }

        [HttpDelete("{userName}")]
        [Authorize(Roles = "Tutor,Student")]
        public ActionResult Delete(string userName)
        {
            var student = studentRepo.GetStudent(userName);
            if (student == null)
                return NotFound();

            studentRepo.DeleteStudent(student);
            return NoContent();
        }
    }
}
