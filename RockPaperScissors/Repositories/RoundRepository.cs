using AutoMapper;
using RockPaperScissors.Data;
using RockPaperScissors.Models;
using RockPaperScissors.Repositories.Interfaces;

namespace RockPaperScissors.Repositories
{
    public class RoundRepository : RepositoryBase<Round>, IRoundRepository
    {
        public RoundRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }
    }
}
