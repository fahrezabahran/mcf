using MCFWebApi.Models;
using MCFWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MCFWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BpkbController : ControllerBase
    {
        private readonly IGenericRepository<Bpkb> _repository;

        public BpkbController(IGenericRepository<Bpkb> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Bpkb>> CreateBpkb(Bpkb Bpkb)
        {
            await _repository.CreateAsync(Bpkb);
            return CreatedAtAction(nameof(GetBpkbById), new { id = Bpkb.AgreementNumber }, Bpkb);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bpkb>>> GetBpkbs()
        {
            var Bpkbs = await _repository.GetAllAsync();
            return Ok(Bpkbs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bpkb>> GetBpkbById(string id)
        {
            var Bpkb = await _repository.GetByIdAsync(id);
            if (Bpkb == null)
            {
                return NotFound();
            }
            return Ok(Bpkb);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBpkb(string id, Bpkb Bpkb)
        {
            if (id != Bpkb.AgreementNumber)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync(Bpkb);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBpkb(string id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
