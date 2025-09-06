using Api.Models.Dtos;

namespace Api.Services;

public interface IPersonService
{
    Task<IEnumerable<PersonReadDto>> GetAllPersonsAsync();
    Task<PersonReadDto> CreatePersonAsync(PersonCreateDto dto);
    Task<bool> DeletePersonAsync(int id);
    Task<PersonReadDto?> UpdatePersonAsync(int id, PersonCreateDto dto);
}
