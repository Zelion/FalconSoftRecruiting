using System.Threading.Tasks;
using ExerciseA.Domain.UnitsOfWork;
using ExerciseA.Implementation.DbContexts;

namespace ExerciseA.Implementation.UnitsOfWork
{
    public class BaseUnitOfWork : IBaseUnitOfWork
    {
        private readonly ExerciseAContext dbContext;

        public BaseUnitOfWork(ExerciseAContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
