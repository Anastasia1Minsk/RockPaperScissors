using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockPaperScissors.Models;

namespace RockPaperScissors.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasMany(x => x.FirstPlayers).WithOne(x => x.FirstPlayer);
            builder.HasMany(x => x.SecondPlayers).WithOne(x => x.SecondPlayer);
            builder.HasMany(x => x.GameWinners).WithOne(x => x.Winner);
            builder.HasMany(x => x.GameWinners).WithOne(x => x.Winner);
        }
    }
}
