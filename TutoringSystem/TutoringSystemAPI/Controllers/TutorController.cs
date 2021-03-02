using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemAPI.Repositories;

namespace TutoringSystemAPI.Controllers
{
    [Route("api/tutor")]
    [Authorize]
    public class TutorController : ControllerBase
    {
        private readonly ITutorRepository tutorRepo;
        private readonly IMapper mapper;

        public TutorController(ITutorRepository tutorRepo, IMapper mapper)
        {
            this.tutorRepo = tutorRepo;
            this.mapper = mapper;
        }

        
    }
}
