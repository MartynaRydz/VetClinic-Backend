using Microsoft.AspNetCore.Mvc;
using VetClinicBackend.DbModels;
using VetClinicBackend.Model;
using VetClinicBackend.Service.OwnerService;
using VetClinicBackend.Service.PetService;

namespace VetClinicBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController(IOwnerService ownerService)
    {

        [HttpGet("GetOwners")]
        public IEnumerable<OwnerDto> GetAllOwners()
        {
            return ownerService.GetOwners();
        }

        [HttpPost("AddOwner")]
        public ActionResult<bool> AddOwner([FromBody] OwnerDto owner)
        {
            return ownerService.AddOwner(owner);
        }

        [HttpPut("EditOwner")]
        public ActionResult<bool> EditOwner([FromBody] OwnerDto owner)
        {
            return ownerService.EditOwner(owner);
        }

        [HttpDelete("DeleteOwner/{id:int}")]
        public ActionResult<bool> DeleteOwner(int id)
        {
            return ownerService.DeleteOwner(id);
        }
    }
}
