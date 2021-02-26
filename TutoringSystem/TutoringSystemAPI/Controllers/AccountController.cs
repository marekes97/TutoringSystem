using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemAPI.Identity;
using TutoringSystemAPI.Repositories;
using TutoringSystemLib.Entities;
using TutoringSystemLib.Models;

namespace TutoringSystemAPI.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IStudentRepository studentRepo;
        private readonly AppDbContext dbContext;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly IJwtProvider jwtProvider;
        private readonly IMapper mapper;

        public AccountController(IStudentRepository studentRepo, AppDbContext dbContext, IPasswordHasher<User> passwordHasher, IJwtProvider jwtProvider, IMapper mapper)
        {
            this.studentRepo = studentRepo;
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
            this.jwtProvider = jwtProvider;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterUserDto registerUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newUser = mapper.Map<Student>(registerUserDto);
            newUser.Role = Role.Student;

            var passwordHash = passwordHasher.HashPassword(newUser, registerUserDto.Password);
            newUser.PasswordHash = passwordHash;

            studentRepo.CreateStudent(newUser);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginUserDto loginUserDto)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.UserName.Equals(loginUserDto.UserName));

            if (user == null)
                return BadRequest("Invalid username of password!");

            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUserDto.Password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
                return BadRequest("Invalid username of password!");

            var token = jwtProvider.GenerateJwtToken(user);
            return Ok(token);
        }
    }
}
