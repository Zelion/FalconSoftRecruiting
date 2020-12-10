using System.Threading.Tasks;
using ExerciseA.Domain.Entities;

namespace ExerciseA.Domain.Respositories
{
    public interface IUserRepository
    {
        public Task<UserInfo> GetUser(string email, string password);
    }
}
