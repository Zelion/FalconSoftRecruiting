using System.Threading.Tasks;
using ExerciseA.Domain.DataContext;

namespace ExerciseA.Domain.UnitsOfWork
{
    public interface IOrderUnitOfWork
    {
        Task UpdateDetailAsync(OrderDetailDataContext dataContext);
    }
}
