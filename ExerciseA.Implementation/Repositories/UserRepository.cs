using System.Threading.Tasks;
using ExerciseA.Domain.Entities;
using ExerciseA.Domain.Respositories;
using ExerciseA.Implementation.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ExerciseA.Implementation.Repositories
{
    public class UserRepository : BaseRepository<UserInfo>, IUserRepository
    {
        public UserRepository(ExerciseAContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserInfo> GetUser(string email, string password)
        {
            return await dbContext.Set<UserInfo>()
                            .FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password));
        }

    }
}
