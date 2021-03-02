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
    [Route("api/tutor/reservation")]
    public class TutorReservationController : ControllerBase
    {
        private readonly IReservationRepository reservationRepo;
        private readonly IMapper mapper;

        public TutorReservationController(IReservationRepository reservationRepo, IMapper mapper)
        {
            this.reservationRepo = reservationRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Tutor")]
        public ActionResult<List<TutorReservationDetailsDto>> Get()
        {
            var userName = User.FindFirst(c => c.Type == ClaimTypes.Name).Value;
            var reservations = reservationRepo.GetTutorReservations(userName);

            var reservationsDtos = mapper.Map<List<ReservationDto>>(reservations);
            return Ok(reservationsDtos);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Tutor")]
        public ActionResult<List<TutorReservationDetailsDto>> Get(int id)
        {
            var userName = User.FindFirst(c => c.Type == ClaimTypes.Name).Value;
            var reservation = reservationRepo.GetTutorReservation(id, userName);
            var reservationsDto = mapper.Map<TutorReservationDetailsDto>(reservation);
            return Ok(reservationsDto);
        }
    }
}
