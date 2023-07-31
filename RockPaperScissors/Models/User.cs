namespace RockPaperScissors.Models
{
    public class User : Model
    {
        public string Name { get; set; }

        public ICollection<Game> FirstPlayers { get; set; }
        public ICollection<Game> SecondPlayers { get; set; }
        public ICollection<Game> GameWinners { get; set; }
        public ICollection<Round> RoundWinners { get; set; }
    }
}
