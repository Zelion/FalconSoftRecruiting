using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseA.Domain.DataContext;
using ExerciseA.Domain.Entities;
using ExerciseA.Domain.Filters;
using ExerciseA.Domain.Respositories;
using ExerciseA.Domain.UnitsOfWork;

namespace ExerciseA.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderUnitOfWork orderUnitOfWork;

        public OrderService(
            IOrderRepository orderRepository,
            IOrderUnitOfWork orderUnitOfWork
            )
        {
            this.orderRepository = orderRepository;
            this.orderUnitOfWork = orderUnitOfWork;
        }

        public async Task<IEnumerable<Order>> GetOrders(PaginationFilter paginationFilter, SortingFilter sortingFilter, GetAllOrdersFilter filter = null)
        {
            return await orderRepository.GetAllFilteredAsync(paginationFilter, sortingFilter, filter);
        }

        public async Task UpdateDetailAsync(OrderDetailDataContext dataContext, long id)
        {
            dataContext.Id = id;
            await orderUnitOfWork.UpdateDetailAsync(dataContext);
        }
    }
}
