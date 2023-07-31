using AutoMapper;
using RockPaperScissors.ModelsDto;

namespace RockPaperScissors.Models
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            CreateMap<Game, GameDto>();
            CreateMap<Round, RoundDto>();
        }
    }
}
