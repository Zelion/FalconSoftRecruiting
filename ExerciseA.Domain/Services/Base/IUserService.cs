using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseA.Domain.Entities;

namespace ExerciseA.Domain.Services
{
    public interface IUserService
    {
        public Task<UserInfo> GetUser(string email, string password);
    }
}
