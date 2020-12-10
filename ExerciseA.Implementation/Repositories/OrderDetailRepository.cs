using ExerciseA.Domain.Entities;
using ExerciseA.Domain.Respositories;
using ExerciseA.Implementation.DbContexts;

namespace ExerciseA.Implementation.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ExerciseAContext dbContext) : base(dbContext)
        {

        }
    }
}
