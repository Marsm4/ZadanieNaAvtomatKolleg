using Microsoft.AspNetCore.Mvc;
using ZadanieNaAvtomatKolleg;

namespace ZadanieNaAvtomatKollegApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialnostController : ControllerBase
    {
        private readonly SpecialnostService _specialnostService;

        public SpecialnostController(SpecialnostService specialnostService)
        {
            _specialnostService = specialnostService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Specialnost>> GetAllSpecialnosti()
        {
            var specialnosti = _specialnostService.GetAll();
            return Ok(specialnosti);
        }

        [HttpGet("{id}")]
        public ActionResult<Specialnost> GetSpecialnostById(int id)
        {
            var specialnost = _specialnostService.GetById(id);
            if (specialnost == null)
                return NotFound();

            return Ok(specialnost);
        }

        [HttpPost]
        public ActionResult<Specialnost> AddSpecialnost([FromBody] Specialnost specialnost)
        {
            _specialnostService.Add(specialnost);
            return CreatedAtAction(nameof(GetSpecialnostById), new { id = specialnost.ID_Specialnosti }, specialnost);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSpecialnost(int id, [FromBody] Specialnost specialnost)
        {
            if (id != specialnost.ID_Specialnosti)
                return BadRequest();

            _specialnostService.Update(specialnost);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSpecialnost(int id)
        {
            var specialnost = _specialnostService.GetById(id);
            if (specialnost == null)
                return NotFound();

            _specialnostService.Delete(id);
            return NoContent();
        }
    }
}
