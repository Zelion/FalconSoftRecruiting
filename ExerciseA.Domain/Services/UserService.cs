using System.Threading.Tasks;
using ExerciseA.Domain.Entities;
using ExerciseA.Domain.Respositories;

namespace ExerciseA.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserInfo> GetUser(string email, string password)
        {
            return await userRepository.GetUser(email, password);
        }
    }
}
