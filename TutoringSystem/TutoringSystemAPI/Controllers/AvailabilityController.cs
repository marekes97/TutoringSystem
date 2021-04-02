using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TutoringSystemAPI.Repositories;
using TutoringSystemLib.Entities;
using TutoringSystemLib.Models;

namespace TutoringSystemAPI.Controllers
{
    [Route("api/tutor/availability")]
    [Authorize]
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityRepository availabilityRepo;
        private readonly IMapper mapper;

        public AvailabilityController(IAvailabilityRepository availabilityRepo, IMapper mapper)
        {
            this.availabilityRepo = availabilityRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Tutor")]
        public ActionResult<List<AvailabilityController>> Get()
        {
            var userName = User.FindFirst(c => c.Type == ClaimTypes.Name).Value;

            var availabilities = availabilityRepo.GetAvailabilities(userName);
            var availabilitiesDtos = mapper.Map<List<AvailabilityDto>>(availabilities);

            return Ok(availabilitiesDtos);
        }

        [HttpGet("{userName}")]
        [Authorize(Roles = "Tutor,Student")]
        public ActionResult<List<AvailabilityController>> Get(string userName)
        {
            var availabilities = availabilityRepo.GetAvailabilities(userName);
            var availabilitiesDtos = mapper.Map<List<AvailabilityDto>>(availabilities);

            return Ok(availabilitiesDtos);
        }
    }
}
