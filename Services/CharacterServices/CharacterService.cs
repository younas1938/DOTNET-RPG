using AutoMapper;
using DOTNET_RPG.Dtos.Character;
using DOTNET_RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNET_RPG.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {
        new Character(),
        new Character{Id=1, Name="Younas"}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServerResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServerResponse<List<GetCharacterDto>> serverResponse = new ServerResponse<List<GetCharacterDto>>();
            //issue will be that id will be by default is 0, so that's what i want that user should not enter his id
            //characters.Add(_mapper.Map<Character>(newCharacter));
            //solution will be below
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(m => m.Id) + 1;
            characters.Add(character);
            serverResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serverResponse;
        }

        public async Task<ServerResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServerResponse<List<GetCharacterDto>> serverResponse = new ServerResponse<List<GetCharacterDto>>();
            try
            {
                // First and FirstOrDefault differnce is that, FirstOrDefaul will return Null if not FOund
                // But First will Throw an exception, now take advantage of that in our try catch exception
                Character character = characters.First(c => c.Id == id);
                characters.Remove(character);
                // return map list of the characters , similar to the GetAllCharacters 
                serverResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                serverResponse.Succes = 0;
                serverResponse.Message = ex.Message;
            }

            return serverResponse;
        }

        public async Task<ServerResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServerResponse<List<GetCharacterDto>> serverResponse = new ServerResponse<List<GetCharacterDto>>();
            // return map list of the characters
            serverResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serverResponse;
        }

        public async Task<ServerResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServerResponse<GetCharacterDto> serverResponse = new ServerResponse<GetCharacterDto>();
            serverResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(x => x.Id == id));
            return serverResponse;
        }

        public async Task<ServerResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServerResponse<GetCharacterDto> serverResponse = new ServerResponse<GetCharacterDto>();
            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == updateCharacter.Id);
                character.Name = updateCharacter.Name;
                character.Class = updateCharacter.Class;
                character.Defense = updateCharacter.Defense;
                character.HitPoints = updateCharacter.HitPoints;
                character.Intelligence = updateCharacter.Intelligence;
                character.Strength = updateCharacter.Strength;

                serverResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {

                serverResponse.Succes = 0;
                serverResponse.Message = ex.Message;
            }
          
            return serverResponse;

        }
    }
}
