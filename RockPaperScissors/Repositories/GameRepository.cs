using AutoMapper;
using RockPaperScissors.Data;
using RockPaperScissors.Models;
using RockPaperScissors.Repositories.Interfaces;

namespace RockPaperScissors.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }
    }
}
