using Microsoft.AspNetCore.Mvc;
using VetClinicBackend.Model;
using VetClinicBackend.Service.PetService;

namespace VetClinicBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController(IPetService petService)
{
    [HttpGet("GetPets")]
    public IEnumerable<PetDto> GetAllPets()
    {
        return petService.GetPets();
    }

    [HttpGet("GetPet/{id:int}")]
    public PetDto GetAllPet(int id)
    {
        return petService.GetPet(id);
    }

    [HttpPost("AddPet")]
    public bool AddPet([FromBody] PetDto pet)
    {
        return petService.AddPet(pet);
    }

    [HttpPut("EditPet")]
    public bool EditPet([FromBody] PetDto pet)
    {
        return petService.EditPet(pet);
    }

    [HttpDelete("DeletePet/{id:int}")]
    public bool DeletePet(int id)
    {
        return petService.DeletePet(id);
    }
}

