using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAM_MB_API.Data;
using PAM_MB_API.Models;
using PAM_MB_API.Models.Enums;

namespace PAM_MB_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MusicoGeneroController : ControllerBase
    {
        private readonly DataContext _context;
        public MusicoGeneroController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("associar")]
        public async Task<IActionResult> AddMusicoGeneroAsync(MusicoGenero novoMusicoGenero)
        {
            try
            {
                var musico = await _context.TB_MUSICOS
                    .FirstOrDefaultAsync(m => m.Id == novoMusicoGenero.MusicoId);
                if (musico == null)
                    return NotFound("Músico não encontrado.");

                var genero = await _context.TB_GENERO
                    .FirstOrDefaultAsync(g => g.Id == novoMusicoGenero.GeneroId);
                if (genero == null)
                    return NotFound("Gênero não encontrado.");

                var existe = await _context.TB_MUSICO_GENERO
                    .AnyAsync(mg => mg.MusicoId == novoMusicoGenero.MusicoId && mg.GeneroId == novoMusicoGenero.GeneroId);

                if (existe)
                    return BadRequest("Associação já existe.");

                await _context.TB_MUSICO_GENERO.AddAsync(novoMusicoGenero);
                await _context.SaveChangesAsync();

                return Ok("Associação criada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{musicoId}")]
        public async Task<IActionResult> GetGenerosDoMusico(int musicoId)
        {
            try
            {
                var generos = await _context.TB_MUSICO_GENERO
                    .Where(mg => mg.MusicoId == musicoId)
                    .Include(mg => mg.genero)
                    .ToListAsync();

                return Ok(generos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMusicoGenero(MusicoGenero dados)
        {
            try
            {
                var associacao = await _context.TB_MUSICO_GENERO
                    .FirstOrDefaultAsync(mg =>
                        mg.MusicoId == dados.MusicoId &&
                        mg.GeneroId == dados.GeneroId);

                if (associacao == null)
                    return NotFound("Associação não encontrada.");

                _context.TB_MUSICO_GENERO.Remove(associacao);
                await _context.SaveChangesAsync();

                return Ok("Associação removida com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}