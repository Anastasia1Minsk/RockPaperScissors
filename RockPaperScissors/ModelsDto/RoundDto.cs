using RockPaperScissors.Models.Enums;

namespace RockPaperScissors.ModelsDto
{
    public class RoundDto
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int? WinnerId { get; set; }
        public string WinnerName { get; set; }
        public int RoundNumber { get; set; }
        public Figure FirstPlayerFigure { get; set; }
        public Figure SecondPlayerFigure { get; set; }
    }
}
