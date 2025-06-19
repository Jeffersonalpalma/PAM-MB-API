using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAM_MB_API.Data;
using PAM_MB_API.Models;
using PAM_MB_API.Models.Enums;

namespace PAM_MB_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MusicosController : ControllerBase
    {
        private readonly DataContext _context;
        public MusicosController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Musico m = await _context.TB_MUSICOS
                    .Include(u => u.Usuario)
                    .Include(g => g.musicogenero)
                        .ThenInclude(g => g.genero)
                    .Include(i => i.musicoinstrumento)
                        .ThenInclude(i => i.instrumento)
                    .Include(d => d.musicodisponibilidade)
                    .ThenInclude(d=>d.disponibilidade)
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(m);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

    }
}