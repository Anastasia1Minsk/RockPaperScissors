using AutoMapper;
using RockPaperScissors.Data;
using RockPaperScissors.Models;
using RockPaperScissors.Repositories.Interfaces;

namespace RockPaperScissors.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }
    }
}
