using RockPaperScissors.Models;
using RockPaperScissors.Models.Enums;
using RockPaperScissors.ModelsDto;
using RockPaperScissors.Repositories.Interfaces;
using RockPaperScissors.Services.Interfaces;

namespace RockPaperScissors.Services
{
    public class GameService : ServiceBase<Game>, IGameService
    {
        private readonly IRoundService _roundService;
        public GameService(IGameRepository repository, IRoundService roundService) : base(repository)
        {
            _roundService = roundService;
        }

        public async Task<Game> GetGameAsync(int gameId) => await RepositoryBase.GetSingleAsync(x => x.Id == gameId);

        public async Task<List<Game>> GetListAsync(bool onlyActiveGames)
        {
            return await RepositoryBase.GetAsync(x => !onlyActiveGames || !x.IsFinished);
        }

        public async Task<int> CreateGameAsync(User creater)
        {
            var game = new Game()
            {
                FirstPlayerId = creater.Id,
                IsFinished = false,                
            };

            await InsertAsync(game);

            return game.Id;                
        }

        public async Task<bool> JoinGameAsync(int gameId, User secondPlayer)
        {
            var game = await GetGameAsync(gameId);

            if (game == null)
            {                
                return false;
            }

            if (game.SecondPlayerId != null)
            {
                return false;
            }

            if (game.FirstPlayerId == secondPlayer.Id)
            {
                return false;
            }

            game.SecondPlayerId = secondPlayer.Id;
            await UpdateAsync(game);
            return true;
        }

        public async Task<string> TurnAsync(int gameId, int userId, Figure figure)
        {
            var game = await GetGameAsync(gameId);
            var error = PossibleToTurn(game, userId);
            if (error != string.Empty)
            {
                return error;
            }

            var isFirstPlayerTurn = game.FirstPlayerId == userId;
            var openRound = await _roundService.GetOpenRound(game.Id);
            if (openRound == null)
            {                
                await _roundService.CreateRoundAsync(game.Id, isFirstPlayerTurn, figure);
                return string.Empty;
            }

            if ((isFirstPlayerTurn && openRound.FirstPlayerFigure is not null)
                || (!isFirstPlayerTurn && openRound.SecondPlayerFigure is not null))
            {
                return "Turn was made";
            }

            openRound = _roundService.FigureToPlayer(openRound, isFirstPlayerTurn, figure);
            openRound = _roundService.DefineWinner(game, openRound);
            await _roundService.UpdateAsync(openRound);

            var possibleToWinAfterRound = 2;
            if(openRound.RoundNumber > possibleToWinAfterRound)
            {
                game = await UpdateGameStatus(game);
            }            
            else
            {
                game.IsFinished = false;
            }
            await UpdateAsync(game);

            return string.Empty;            
        }
        
        private string PossibleToTurn(Game game, int userId)
        {
            if (game == null)
            {
                return "Game isn't find";
            }

            if (game.IsFinished)
            {
                return "Game was finished";
            }

            if (game.FirstPlayerId != userId && game.SecondPlayerId != userId)
            {
                return "User doesn't participate in the game";
            }
            
            return string.Empty;
        }

        private async Task<Game> UpdateGameStatus(Game game)
        {
            var preliminaryVictory = 3;
            var rounds = await _roundService.GetListAsync(game.Id);

            if (rounds.Where(x => x.WinnerId == 0).Count() == preliminaryVictory)
            {
                game.WinnerId = 0;
                game.IsFinished = true;
                return game;
            }

            if (rounds.Where(x => x.WinnerId == game.FirstPlayerId).Count() == preliminaryVictory)
            {
                game.WinnerId = game.FirstPlayerId;
                game.IsFinished = true;
                return game;
            }

            if (rounds.Where(x => x.WinnerId == game.SecondPlayerId).Count() == preliminaryVictory)
            {
                game.WinnerId = game.SecondPlayerId;
                game.IsFinished = true;
                return game;
            }

            game.IsFinished = false;
            return game;
        }
    }
}
