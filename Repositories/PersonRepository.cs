using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class PersonRepository(AppDbContext context) : IPersonRepository
{
    private readonly AppDbContext _context = context;
    public async Task<IEnumerable<Person>> GetAllPersonsAsync()
    {
        return await _context.Persons.OrderBy(m => m.PersonId).ToListAsync();
    }
    public async Task<Person> AddPersonAsync(Person person)
    {
        _context.Persons.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task<bool> DeletePersonAsync(int id)
    {
        var person = await _context.Persons.FindAsync(id);
        if (person == null) return false;

        _context.Persons.Remove(person);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<Person?> GetPersonByIdAsync(int id)
    {
        return await _context.Persons.FindAsync(id);
    }

    public async Task<Person?> UpdatePersonAsync(Person person)
    {
        var existing = await _context.Persons.FindAsync(person.PersonId);
        if (existing == null) return null;

        existing.FirstName = person.FirstName;
        existing.LastName = person.LastName;
        existing.Email = person.Email;
        existing.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();
        return existing;
    }
}
