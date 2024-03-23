using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _6lr.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PhonesController : ControllerBase{

        private readonly IPhonesService _phonesService;

        public PhonesController(IPhonesService phonesService)
        {
            _phonesService = phonesService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var phones = await _phonesService.GetPhones();
            return Ok(phones);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Phones phone)
        {
            await _phonesService.AddPhone(phone);
            return CreatedAtAction(nameof(Get), new { id = phone.Id }, phone);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Phones phone)
        {
            if (id != phone.Id)
            {
                return BadRequest();
            }

            await _phonesService.UpdatePhone(phone);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _phonesService.DeletePhone(id);
            return NoContent();
        }
    }
}
