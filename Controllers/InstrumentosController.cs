using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAM_MB_API.Models;
using PAM_MB_API.Data; 

namespace PAM_MB_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstrumentosController : ControllerBase
    {
        private readonly DataContext _context;

        public InstrumentosController(DataContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instrumento>>> GetInstrumentos()
        {
            var instrumentos = await _context.TB_INSTRUMENTO.ToListAsync();
            return Ok(instrumentos);
        }
    }
}
