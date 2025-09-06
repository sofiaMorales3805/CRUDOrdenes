using Api.Models;
using Api.Models.Dtos;
using Api.Repositories;

namespace Api.Services;
public class PersonService : IPersonService
{
    private readonly IPersonRepository _repository;
    public PersonService(IPersonRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<PersonReadDto>> GetAllPersonsAsync()
    {
        var entities = await _repository.GetAllPersonsAsync();
        return entities.Select(p => MapToReadDto(p));
    }

    public async Task<PersonReadDto> CreatePersonAsync(PersonCreateDto dto)
    {
        var entity = new Person
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };

        var created = await _repository.AddPersonAsync(entity);
        return MapToReadDto(created);
    }

    public async Task<bool> DeletePersonAsync(int id)
    {
        return await _repository.DeletePersonAsync(id);       
    }
    public async Task<PersonReadDto?> UpdatePersonAsync(int id, PersonCreateDto dto)
    {
        var entity = new Person
        {
            PersonId = id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            UpdatedAt = DateTime.Now
        };

        var updated = await _repository.UpdatePersonAsync(entity);
        return updated == null ? null : MapToReadDto(updated);
    }

    //Mapea la entidad a Dtos
    private static PersonReadDto MapToReadDto(Person p) => new()
    {
        PersonId = p.PersonId,
        FirstName = p.FirstName,
        LastName = p.LastName,
        Email = p.Email
    };
}
