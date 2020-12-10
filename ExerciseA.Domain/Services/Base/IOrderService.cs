using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseA.Domain.DataContext;
using ExerciseA.Domain.Entities;
using ExerciseA.Domain.Filters;

namespace ExerciseA.Domain.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> GetOrders(PaginationFilter paginationRequest, SortingFilter sortingFilter, GetAllOrdersFilter filter = null);
        Task UpdateDetailAsync(OrderDetailDataContext dataContext, long id);
    }
}
