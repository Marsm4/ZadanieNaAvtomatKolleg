using Microsoft.AspNetCore.Mvc;
using ZadanieNaAvtomatKolleg;

namespace ZadanieNaAvtomatKollegApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZavOtdeleniaController : ControllerBase
    {
        private readonly ZavOtdeleniaService _zavOtdeleniaService;

        public ZavOtdeleniaController(ZavOtdeleniaService zavOtdeleniaService)
        {
            _zavOtdeleniaService = zavOtdeleniaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Zav_Otdelenia>> GetAllZavOtdelenia()
        {
            var zavOtdelenia = _zavOtdeleniaService.GetAll();
            return Ok(zavOtdelenia);
        }

        [HttpGet("{id}")]
        public ActionResult<Zav_Otdelenia> GetZavOtdeleniaById(int id)
        {
            var zavOtdelenia = _zavOtdeleniaService.GetById(id);
            if (zavOtdelenia == null)
                return NotFound();

            return Ok(zavOtdelenia);
        }

        [HttpPost]
        public ActionResult<Zav_Otdelenia> AddZavOtdelenia([FromBody] Zav_Otdelenia zavOtdelenia)
        {
            _zavOtdeleniaService.Add(zavOtdelenia);
            return CreatedAtAction(nameof(GetZavOtdeleniaById), new { id = zavOtdelenia.ID_zav_Otdelenia }, zavOtdelenia);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateZavOtdelenia(int id, [FromBody] Zav_Otdelenia zavOtdelenia)
        {
            if (id != zavOtdelenia.ID_zav_Otdelenia)
                return BadRequest();

            _zavOtdeleniaService.Update(zavOtdelenia);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteZavOtdelenia(int id)
        {
            var zavOtdelenia = _zavOtdeleniaService.GetById(id);
            if (zavOtdelenia == null)
                return NotFound();

            _zavOtdeleniaService.Delete(id);
            return NoContent();
        }
    }
}
