using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockPaperScissors.Models;

namespace RockPaperScissors.Data.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");

            builder.HasOne(x => x.FirstPlayer).WithMany(x => x.FirstPlayers);
            builder.HasOne(x => x.SecondPlayer).WithMany(x => x.SecondPlayers);
            builder.HasOne(x => x.Winner).WithMany(x => x.GameWinners);
            builder.HasMany(x => x.Rounds).WithOne(x => x.Game);
        }
    }
}
