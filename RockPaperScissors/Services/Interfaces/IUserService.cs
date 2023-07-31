using RockPaperScissors.Models;

namespace RockPaperScissors.Services.Interfaces
{
    public interface IUserService : IServiceBase<User>
    {
        Task<User> GetOrCreateUserAsync(string name);
        Task<User> GetUserAsync(int userId);
    }
}
