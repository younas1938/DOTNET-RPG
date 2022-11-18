using AutoMapper;
using DOTNET_RPG.Dtos.Character;
using DOTNET_RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNET_RPG
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            // in this case we are retrieving data from src 'Cahracter' to destination 'GetCharacterDto' to show infront of
            CreateMap<Character, GetCharacterDto>();
            // but in this case we are pasing data from view so the source will be 'CharacterDTO' to destination table 'Character'
            CreateMap<AddCharacterDto, Character>();

        }
       
    }
}
