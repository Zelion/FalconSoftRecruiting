using System.Threading.Tasks;
using ExerciseA.Domain.Entities;
using ExerciseA.Domain.Respositories;
using ExerciseA.Implementation.DbContexts;

namespace ExerciseA.Implementation.Repositories
{
    public class BaseRepository<E> : IBaseRepository<E> where E : BaseEntity
    {
        protected readonly ExerciseAContext dbContext;

        public BaseRepository(ExerciseAContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<E> GetByID(long id) => await dbContext.Set<E>().FindAsync(id);
    }
}
