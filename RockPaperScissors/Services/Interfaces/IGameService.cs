using RockPaperScissors.Models;
using RockPaperScissors.Models.Enums;
using RockPaperScissors.ModelsDto;

namespace RockPaperScissors.Services.Interfaces
{
    public interface IGameService : IServiceBase<Game>
    {
        Task<Game> GetGameAsync(int gameId);
        Task<List<Game>> GetListAsync(bool onlyActiveGames);
        Task<int> CreateGameAsync(User creater);
        Task<bool> JoinGameAsync(int gameId, User secondPlayer);
        Task<string> TurnAsync(int gameId, int userId, Figure figure);
    }
}
