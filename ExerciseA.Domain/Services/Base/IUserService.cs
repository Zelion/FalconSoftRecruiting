using System.Threading.Tasks;
using ExerciseA.Domain.Entities;

namespace ExerciseA.Domain.Services
{
    public interface IUserService
    {
        public Task<UserInfo> GetUser(string email, string password);
    }
}
