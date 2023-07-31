namespace RockPaperScissors.Models
{
    public class Game : Model
    {
        public int FirstPlayerId { get; set; }
        public int? SecondPlayerId { get; set; }
        public int? WinnerId { get; set; }
        public bool IsFinished { get; set; }

        public User FirstPlayer { get; set; }
        public User? SecondPlayer { get; set; }
        public User? Winner { get; set; }
        public ICollection<Round> Rounds { get; set; }
    }
}
