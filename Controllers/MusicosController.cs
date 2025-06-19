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
                    .ThenInclude(d => d.disponibilidade)
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(m);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Musico> lista = await _context.TB_MUSICOS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(Musico novoMusico)
        {
            try
            {
                await _context.TB_MUSICOS.AddAsync(novoMusico);
                await _context.SaveChangesAsync();

                return Ok(novoMusico.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Musico novoMusico)
        {
            try
            {
                _context.TB_MUSICOS.Update(novoMusico);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Musico? mRemover = await _context.TB_MUSICOS.FirstOrDefaultAsync(m => m.Id == id);

                _context.TB_MUSICOS.Remove(mRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }



    }
}