using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExerciseA.Domain.Filters;
using ExerciseA.Domain.Services;
using ExerciseA.WebAPI.Controllers.Order.Response;
using ExerciseA.WebAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseA.WebAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/controller")]
    public class OrderController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IOrderService orderService;

        public OrderController(
            IMapper mapper,
            IOrderService orderService
            )
        {
            this.mapper = mapper;
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> Get([FromQuery] PaginationRequest paginationRequest, [FromQuery] GetAllOrdersFilterRequest filterRequest = null)
        {
            try
            {
                var pagination = mapper.Map<PaginationFilter>(paginationRequest);
                var filter = mapper.Map<GetAllOrdersFilter>(filterRequest);

                var orders = await orderService.GetOrders(pagination, filter);
                var result = mapper.Map<IEnumerable<OrderResponse>>(orders);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
