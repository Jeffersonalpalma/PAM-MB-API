using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAM_MB_API.Data;
using PAM_MB_API.Models;
using PAM_MB_API.Models.Enums;

namespace PAM_MB_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MusicoInstrumentosController : ControllerBase
    {
        private readonly DataContext _context;
        public MusicoInstrumentosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> AddMusicoInstrumentoAsync(MusicoInstrumento novoMusicoInstrumento)
        {
            try
            {
                var music = await _context.TB_MUSICOS
                    .Include(m => m.musicoinstrumento)
                    .ThenInclude(mi => mi.instrumento)
                    .FirstOrDefaultAsync(m => m.Id == novoMusicoInstrumento.MusicoId);

                if (music == null)
                    throw new Exception("Músico não encontrado para o Id informado.");

                var instrument = await _context.TB_INSTRUMENTO
                    .FirstOrDefaultAsync(i => i.Id == novoMusicoInstrumento.InstrumentoId);

                if (instrument == null)
                    throw new Exception("Instrumento não encontrado.");

                var musicoInstrumento = new MusicoInstrumento
                {
                    musico = music,
                    instrumento = instrument
                };

                await _context.TB_MUSICO_INSTRUMENTO.AddAsync(musicoInstrumento);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - {ex.InnerException?.Message}");
            }
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetMusicoInstrumentos()
        {
            try
            {
                var lista = await _context.TB_MUSICO_INSTRUMENTO
                    .Include(mi => mi.musico)
                    .Include(mi => mi.instrumento)
                    .ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar dados: {ex.Message}");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMusicoInstrumento(MusicoInstrumento dados)
        {
            try
            {
                var associacao = await _context.TB_MUSICO_INSTRUMENTO
                    .FirstOrDefaultAsync(mi => mi.MusicoId == dados.MusicoId && mi.InstrumentoId == dados.InstrumentoId);

                if (associacao == null)
                    return NotFound("Associação não encontrada.");

                _context.TB_MUSICO_INSTRUMENTO.Remove(associacao);
                await _context.SaveChangesAsync();

                return Ok("Associação removida com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao remover: {ex.Message}");
            }
        }
    }
}