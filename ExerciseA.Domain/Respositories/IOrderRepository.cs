using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseA.Domain.Entities;
using ExerciseA.Domain.Filters;

namespace ExerciseA.Domain.Respositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public Task<IEnumerable<Order>> GetAllFilteredAsync(PaginationFilter paginationFilter, SortingFilter sortingFilter, GetAllOrdersFilter filter = null);
    }
}
