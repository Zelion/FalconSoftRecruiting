using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExerciseA.API.Controllers.Order.Response;
using ExerciseA.API.Requests;
using ExerciseA.Domain.DataContext;
using ExerciseA.Domain.Filters;
using ExerciseA.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseA.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/orders")]
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
        public async Task<ActionResult<IEnumerable<OrderResponse>>> Get([FromQuery] PaginationRequest paginationRequest, [FromQuery] SortingRequest sortingrequest, [FromQuery] GetAllOrdersFilterRequest filterRequest = null)
        {
            try
            {
                var pagination = mapper.Map<PaginationFilter>(paginationRequest);
                var filter = mapper.Map<GetAllOrdersFilter>(filterRequest);
                var sorting = mapper.Map<SortingFilter>(sortingrequest);

                var orders = await orderService.GetOrders(pagination, sorting, filter);
                var result = mapper.Map<IEnumerable<OrderResponse>>(orders);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] OrderDetailEditRequest orderDetailEditRequest)
        {
            try
            {
                var orderDetail = mapper.Map<OrderDetailDataContext>(orderDetailEditRequest);
                await orderService.UpdateDetailAsync(orderDetail, id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
