using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseA.Domain.Entities;
using ExerciseA.Domain.Filters;
using ExerciseA.Domain.Respositories;

namespace ExerciseA.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(
            IOrderRepository orderRepository
            )
        {
            this.orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetOrders(PaginationFilter paginationFilter, GetAllOrdersFilter filter = null)
        {
            return await orderRepository.GetAll(paginationFilter, filter);
        }
    }
}
