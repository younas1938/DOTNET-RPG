using DOTNET_RPG.Dtos.Character;
using DOTNET_RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNET_RPG.Services
{
    public interface ICharacterService
    {
        Task<ServerResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServerResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServerResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServerResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter);
        Task<ServerResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}
