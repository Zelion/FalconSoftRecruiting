using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseA.Domain.Entities;
using ExerciseA.Domain.Filters;

namespace ExerciseA.Domain.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> GetOrders(PaginationFilter paginationRequest, GetAllOrdersFilter filter = null);
    }
}
