using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockPaperScissors.Models;

namespace RockPaperScissors.Data.Configurations
{
    public class RoundConfiguration : IEntityTypeConfiguration<Round>
    {
        public void Configure(EntityTypeBuilder<Round> builder)
        {
            builder.ToTable("Rounds");

            builder.HasOne(x => x.Winner).WithMany(x => x.RoundWinners);
            builder.HasOne(x => x.Game).WithMany(x => x.Rounds);
        }
    }
}
