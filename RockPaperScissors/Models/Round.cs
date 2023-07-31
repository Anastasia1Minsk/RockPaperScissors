using RockPaperScissors.Models.Enums;

namespace RockPaperScissors.Models
{
    public class Round : Model
    {
        public int GameId { get; set; }
        public int? WinnerId { get; set; }
        public int RoundNumber { get; set; }
        public Figure? FirstPlayerFigure { get; set; }
        public Figure? SecondPlayerFigure { get; set; }

        public User? Winner { get; set; }
        public Game Game { get; set; }
    }
}
