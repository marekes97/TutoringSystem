using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemAPI.Identity;
using TutoringSystemLib.Entities;
using TutoringSystemLib.Models;

namespace TutoringSystemAPI.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly IJwtProvider jwtProvider;

        public AccountController(AppDbContext dbContext, IPasswordHasher<User> passwordHasher, IJwtProvider jwtProvider)
        {
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
            this.jwtProvider = jwtProvider;
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterUserDto registerUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newUser = new Student
            {
                Role = Role.Student,
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                Login = registerUserDto.Login,
                Address = new Address
                {
                    Street = registerUserDto.Street,
                    City = registerUserDto.City,
                    PostalCode = registerUserDto.PostalCode
                },
                Contact = new Contact
                {
                    DiscordName = registerUserDto.DiscordName,
                    Email = registerUserDto.Email,
                    PhoneNumbers = new List<PhoneNumber>
                    {
                        new PhoneNumber
                        {
                            Owner = registerUserDto.PhoneOwner,
                            Number = registerUserDto.PhoneNumber
                        }
                    }
                },
                School = new School
                {
                    Name = registerUserDto.SchoolName,
                    EducationLevel = registerUserDto.EducationLevel,
                    Year = registerUserDto.EducationYear
                }
            };

            var passwordHash = passwordHasher.HashPassword(newUser, registerUserDto.Password);
            newUser.PasswordHash = passwordHash;

            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();

            return Ok();
        }

       
    }
}
