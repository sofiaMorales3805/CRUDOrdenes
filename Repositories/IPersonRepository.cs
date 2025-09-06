using Api.Models;

namespace Api.Repositories;
public interface IPersonRepository
{
    Task<Person> AddPersonAsync(Person person);
    Task<IEnumerable<Person>> GetAllPersonsAsync();
    Task<bool> DeletePersonAsync(int id);
     Task<Person?> UpdatePersonAsync(Person person); 
    Task<Person?> GetPersonByIdAsync(int id);   
}   
