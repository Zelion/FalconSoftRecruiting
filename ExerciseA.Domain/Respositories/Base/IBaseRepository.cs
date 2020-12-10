using System.Threading.Tasks;
using ExerciseA.Domain.Entities;

namespace ExerciseA.Domain.Respositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetByID(long id);
    }
}
