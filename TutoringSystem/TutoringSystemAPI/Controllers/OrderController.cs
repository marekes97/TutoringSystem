using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoringSystemAPI.Repositories;
using TutoringSystemLib.Entities;
using TutoringSystemLib.Models;

namespace TutoringSystemAPI.Controllers
{
    [Route("api/order")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepo;
        private readonly ITutorRepository tutorRepo;
        private readonly IMapper mapper;

        public OrderController(IOrderRepository orderRepo, IMapper mapper, ITutorRepository tutorRepo)
        {
            this.orderRepo = orderRepo;
            this.mapper = mapper;
            this.tutorRepo = tutorRepo;
        }

        [HttpGet]
        [Authorize(Roles = "Tutor")]
        public ActionResult<List<OrderDto>> Get()
        {
            var tutorName = HttpContext.User.Identity.Name;
            var tutor = tutorRepo.GetTutor(tutorName);

            var tutorOrders = orderRepo.GetOrders(tutor);

            if (tutor == null || tutorOrders == null)
                return NotFound();

            var ordersDto = mapper.Map<List<OrderDto>>(tutorOrders);
            return Ok(ordersDto);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Tutor")]
        public ActionResult<OrderDto> Get(int id)
        {
            var tutorName = HttpContext.User.Identity.Name;
            var tutor = tutorRepo.GetTutor(tutorName);

            var order = orderRepo.GetOrder(id, tutor);
            if (order == null || tutor == null)
                return NotFound();

            var orderDto = mapper.Map<OrderDetailsDto>(order);

            return Ok(orderDto);
        }

        [HttpPost]
        [Authorize(Roles = "Tutor")]
        public ActionResult Post([FromBody] OrderDetailsDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = mapper.Map<AdditionalOrder>(model);
            var userName = User.FindFirst(c => c.Type == ClaimTypes.Name).Value;
            var tutor = tutorRepo.GetTutor(userName);
            order.Tutor = tutor;

            if (tutor == null)
                return NotFound();

            orderRepo.AddOrder(order);

            var key = order.Id;
            return Created("api/order/" + key, null);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Tutor")]
        public ActionResult Put(int id, [FromBody] OrderDetailsDto model)
        {
            var tutorName = HttpContext.User.Identity.Name;
            var tutor = tutorRepo.GetTutor(tutorName);
            var order = orderRepo.GetOrder(id, tutor);
            if (order == null)
                return NotFound();

            var newOrder = mapper.Map<AdditionalOrder>(model);
            orderRepo.UpdateOrder(id, newOrder);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Tutor")]
        public ActionResult Delete(int id)
        {
            var tutorName = HttpContext.User.Identity.Name;
            var tutor = tutorRepo.GetTutor(tutorName);
            var order = orderRepo.GetOrder(id, tutor);
            if (order == null)
                return NotFound();

            orderRepo.DeleteOrder(id);

            return NoContent();
        }
    }
}
