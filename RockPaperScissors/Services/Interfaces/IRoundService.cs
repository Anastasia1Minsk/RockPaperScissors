using RockPaperScissors.Models;
using RockPaperScissors.Models.Enums;

namespace RockPaperScissors.Services.Interfaces
{
    public interface IRoundService : IServiceBase<Round>
    {
        Task<Round> GetOpenRound(int gameId);
        Task<List<Round>> GetListAsync(int gameId);
        Task CreateRoundAsync(int gameId, bool isFirstPlayerTurn, Figure figure);
        Round FigureToPlayer(Round round, bool isFirstPlayerTurn, Figure figure);
        Round DefineWinner(Game game, Round round);
    }
}
