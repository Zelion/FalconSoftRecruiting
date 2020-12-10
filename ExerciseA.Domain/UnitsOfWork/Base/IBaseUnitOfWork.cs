using System.Threading.Tasks;

namespace ExerciseA.Domain.UnitsOfWork
{
    public interface IBaseUnitOfWork
    {
        Task CommitAsync();
    }
}
