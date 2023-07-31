using RockPaperScissors.Models;
using RockPaperScissors.Models.Enums;

namespace RockPaperScissors.ModelsDto
{
    public class GameInfoDto
    {
        public Status GameStatus { get; set; }
        public Status CurrentRoundStatus { get; set; }
        public List<RoundDto> Rounds { get; set; }
    }
}
