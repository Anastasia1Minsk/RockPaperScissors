using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Models.Enums;
using RockPaperScissors.ModelsDto;
using RockPaperScissors.Services.Interfaces;
using System.Collections.Generic;

namespace RockPaperScissors.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IUserService _userService;
        private readonly IRoundService _roundService;
        private readonly IMapper _mapper;

        public GameController(IGameService gameService, IUserService userService, IRoundService roundService, IMapper mapper) 
        { 
            _gameService = gameService;
            _userService = userService;
            _roundService = roundService;
            _mapper = mapper;
        }

        [HttpGet, Route("list")]
        public async Task<IActionResult> GetListAsync(bool onlyActiveGames = false)
        {
            var list = await _gameService.GetListAsync(onlyActiveGames);
            return Ok(_mapper.Map<List<GameDto>>(list));
        }

        [HttpPost, Route("start/{userName}")]
        public async Task<IActionResult> StartGameAsync(string userName)
        {
            var creater = await _userService.GetOrCreateUserAsync(userName.Trim());
            var gameId = await _gameService.CreateGameAsync(creater);
            return Ok(new 
            {
                GameId = gameId,
                UserId = creater.Id
            });
        }

        [HttpPut, Route("{gameId:int}/join/{userName}")]
        public async Task<IActionResult> JoinGameAsync(int gameId, string userName)
        {
            var secondPlayer = await _userService.GetOrCreateUserAsync(userName.Trim());
            if(await _gameService.JoinGameAsync(gameId, secondPlayer))
            {
                return Ok(secondPlayer.Id);
            }
            
            return BadRequest("Impossible to connect");
        }

        [HttpPut, Route("{gameId:int}/user/{userId:int}/{figure}")]
        public async Task<IActionResult> StepAsync(int gameId, int userId, Figure figure)
        {
            var player = await _userService.GetUserAsync(userId);
            if(player == null)
            {
                return BadRequest("User isn't exist");
            }

            var turnErrors = await _gameService.TurnAsync(gameId, player.Id, figure);
            if (turnErrors != string.Empty)
            {
                return BadRequest(turnErrors);
            }

            var info = new GameInfoDto();
            var game = await _gameService.GetGameAsync(gameId);            
            var rounds = await _roundService.GetListAsync(game.Id);
            info.Rounds = _mapper.Map<List<RoundDto>>(rounds);
            info.GameStatus = game.IsFinished switch
            {
                true when game.WinnerId == 0 => Status.Draw,
                true when game.WinnerId == userId => Status.YouWon,
                true when game.WinnerId != userId => Status.YouLost,
                _ => Status.Continue
            };

            var currentRound = rounds.MaxBy(x => x.RoundNumber);
            if (currentRound.FirstPlayerFigure == null || currentRound.SecondPlayerFigure == null)
            {
                info.CurrentRoundStatus = Status.Continue;
                return Ok(info);
            }

            if (currentRound.WinnerId == 0)
            {
                info.CurrentRoundStatus = Status.Draw;
                return Ok(info);
            }

            info.CurrentRoundStatus = currentRound.WinnerId == userId ? Status.YouWon : Status.YouLost;


            return Ok(info);
        }

    }
}
