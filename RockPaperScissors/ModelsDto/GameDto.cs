using RockPaperScissors.Models.Enums;

namespace RockPaperScissors.ModelsDto
{
    public class GameDto
    {
        public int Id { get; set; }
        public int FirstPlayerId { get; set; }        
        public string FirstPlayerName { get; set; }
        public int? SecondPlayerId { get; set; }
        public string? SecondPlayerName { get; set; }
        public int? WinnerId { get; set; }
        public string? WinnerName { get; set; }
        public bool IsFinished { get; set; }
    }
}
