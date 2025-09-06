using Microsoft.AspNetCore.Mvc;
using Api.Models.Dtos;
using Api.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service; // Variable para comunicarse con el service

        public PersonController(IPersonService service)
        {
            _service = service;
        }
        //Get de todas las personas
        [HttpGet]// GET api/persons
        public async Task<IActionResult> GetAll()
        {
            var persons = await _service.GetAllPersonsAsync();
            if (persons == null) return NotFound(); // No hay personas NotFound:404
            return Ok(persons); // Si encuentra personas OK:200
        }

        [HttpPost] // POST api/persons
        public async Task<IActionResult> Create(PersonCreateDto dto)
        {
            var person = await _service.CreatePersonAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = person.PersonId }, person);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PersonCreateDto dto)
        {
            var updated = await _service.UpdatePersonAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete] // Delete persona
        public async Task<IActionResult> Delete(int id) { 
             var deleted = await _service.DeletePersonAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
            }
        }
    }
           
