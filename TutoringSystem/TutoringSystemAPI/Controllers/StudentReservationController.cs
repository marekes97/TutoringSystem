using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutoringSystemAPI.Repositories;
using TutoringSystemLib.Models;


namespace TutoringSystemAPI.Controllers
{
    [Route("api/student/reservation")]
    [Authorize]
    public class StudentReservationController : ControllerBase
    {
        private readonly IReservationRepository reservationRepo;
        private readonly IMapper mapper;

        public StudentReservationController(IReservationRepository reservationRepo, IMapper mapper)
        {
            this.reservationRepo = reservationRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult<List<TutorReservationDetailsDto>> Get()
        {
            var userName = User.FindFirst(c => c.Type == ClaimTypes.Name).Value;
            var reservations = reservationRepo.GetStudentReservations(userName);

            var reservationsDtos = mapper.Map<List<ReservationDto>>(reservations);
            return Ok(reservationsDtos);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Student")]
        public ActionResult<List<TutorReservationDetailsDto>> Get(int id)
        {
            var userName = User.FindFirst(c => c.Type == ClaimTypes.Name).Value;
            var reservation = reservationRepo.GetStudentReservation(id, userName);
            var reservationsDto = mapper.Map<StudentReservationDetailsDto>(reservation);
            return Ok(reservationsDto);
        }
    }
}
