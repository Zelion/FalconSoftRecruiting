using System.Threading.Tasks;
using ExerciseA.Domain.DataContext;
using ExerciseA.Domain.Respositories;
using ExerciseA.Domain.UnitsOfWork;
using ExerciseA.Implementation.DbContexts;

namespace ExerciseA.Implementation.UnitsOfWork
{
    public class OrderUnitOfWork : BaseUnitOfWork, IOrderUnitOfWork
    {
        private readonly IOrderDetailRepository orderDetailRepository;

        public OrderUnitOfWork(
            ExerciseAContext dbContext,
            IOrderDetailRepository orderDetailRepository
            ) : base(dbContext)
        {
            this.orderDetailRepository = orderDetailRepository;
        }

        public async Task UpdateDetailAsync(OrderDetailDataContext dataContext)
        {
            var orderDetail = await orderDetailRepository.GetByID(dataContext.Id);
            dataContext.Update(orderDetail);

            await CommitAsync();
        }
    }
}
