using RockPaperScissors.Models.Enums;

namespace RockPaperScissors.ModelsDto
{
    public class GameDto
    {
        public int Id { get; set; }
        public int FirstPlayerId { get; set; }        
        public int FirstPlayerName { get; set; }
        public int? SecondPlayerId { get; set; }
        public int? SecondPlayerName { get; set; }
        public int? WinnerId { get; set; }
        public int? WinnerName { get; set; }
        public bool IsFinished { get; set; }
        public Status Status { get; set; }
    }
}
