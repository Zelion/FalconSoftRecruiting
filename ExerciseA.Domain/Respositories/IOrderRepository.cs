using System.Collections.Generic;
using System.Threading.Tasks;
using ExerciseA.Domain.Entities;
using ExerciseA.Domain.Filters;

namespace ExerciseA.Domain.Respositories
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetAll(PaginationFilter paginationFilter, GetAllOrdersFilter filter = null);
    }
}
