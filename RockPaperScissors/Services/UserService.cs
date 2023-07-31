using RockPaperScissors.Models;
using RockPaperScissors.Repositories.Interfaces;
using RockPaperScissors.Services.Interfaces;

namespace RockPaperScissors.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        public async Task<User> GetOrCreateUserAsync(string name)
        {
            var user = await RepositoryBase.GetSingleAsync(x => x.Name == name);

            if (user != null)
            {
                return user;
            }

            user = new User()
            {
                Name = name
            };

            await InsertAsync(user);

            return user;
        }

        public async Task<User> GetUserAsync(int userId) => await RepositoryBase.GetSingleAsync(x => x.Id == userId);
    }
}
