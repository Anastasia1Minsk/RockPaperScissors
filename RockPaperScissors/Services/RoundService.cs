using RockPaperScissors.Models;
using RockPaperScissors.Models.Enums;
using RockPaperScissors.Repositories.Interfaces;
using RockPaperScissors.Services.Interfaces;

namespace RockPaperScissors.Services
{
    public class RoundService : ServiceBase<Round>, IRoundService
    {
        public RoundService(IRoundRepository repository) : base(repository)
        {
        }

        public async Task<Round> GetOpenRound(int gameId) => await RepositoryBase.GetSingleAsync(x => x.GameId == gameId && !x.WinnerId.HasValue);
        public async Task<List<Round>> GetListAsync(int gameId) => await RepositoryBase.GetAsync(x => x.GameId == gameId);

        public async Task CreateRoundAsync(int gameId, bool isFirstPlayerTurn, Figure figure)
        {
            var round = new Round()
            {
                GameId = gameId,
            };

            var finishedRounds = await RepositoryBase.GetAsync(x => x.GameId == gameId);        
            round.RoundNumber = (finishedRounds == null) ? 0 : finishedRounds.Count + 1;

            round = FigureToPlayer(round, isFirstPlayerTurn, figure);

            await InsertAsync(round);
        }

        public Round FigureToPlayer(Round round, bool isFirstPlayerTurn, Figure figure)
        {
            if (isFirstPlayerTurn)
            {
                round.FirstPlayerFigure = figure;
            }
            else
            {
                round.SecondPlayerFigure = figure;
            }

            return round;
        }

        public Round DefineWinner(Game game, Round round)
        {
            var firstFigure = round.FirstPlayerFigure.GetValueOrDefault();
            var secondFigure = round.SecondPlayerFigure.GetValueOrDefault();

            if (firstFigure == secondFigure)
            {
                round.WinnerId = 0;
                return round;
            }            

            round.WinnerId = RockScissors(firstFigure, secondFigure) 
                            || ScissorsPaper(firstFigure, secondFigure) 
                            || PaperRock(firstFigure, secondFigure)
                            ? game.FirstPlayerId 
                            : game.SecondPlayerId;

            return round;
        }

        private bool RockScissors(Figure firstFigure, Figure secondFigure)
        {
            if (firstFigure == Figure.Rock && secondFigure == Figure.Scissors)
            {
                return true;
            }

            return false;
        }

        private bool ScissorsPaper(Figure firstFigure, Figure secondFigure)
        {
            if (firstFigure == Figure.Scissors && secondFigure == Figure.Paper)
            {
                return true;
            }

            return false;
        }

        private bool PaperRock(Figure firstFigure, Figure secondFigure)
        {
            if (firstFigure == Figure.Paper && secondFigure == Figure.Rock)
            {
                return true;
            }

            return false;
        }
    }
}
