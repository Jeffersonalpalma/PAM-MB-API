using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAM_MB_API.Data;
using PAM_MB_API.Models;
using PAM_MB_API.Models.Enums;

namespace PAM_MB_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MusicoDisponibilidadeController : ControllerBase
    {
        private readonly DataContext _context;
        public MusicoDisponibilidadeController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("associar")]
        public async Task<IActionResult> AddMusicoDisponibilidade(MusicoDisponibilidade novo)
        {
            try
            {
                var musico = await _context.TB_MUSICOS.FindAsync(novo.MusicoId);
                if (musico == null)
                    return NotFound("Músico não encontrado.");

                var disponibilidade = await _context.TB_DISPONIBILIDADE.FindAsync(novo.DisponibilidadeId);
                if (disponibilidade == null)
                    return NotFound("Disponibilidade não encontrada.");

                var existe = await _context.TB_MUSICO_DISPONIBILIDADE
                    .AnyAsync(md => md.MusicoId == novo.MusicoId && md.DisponibilidadeId == novo.DisponibilidadeId);

                if (existe)
                    return BadRequest("Associação já existe.");

                await _context.TB_MUSICO_DISPONIBILIDADE.AddAsync(novo);
                await _context.SaveChangesAsync();

                return Ok("Associação criada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // GET: Listar disponibilidades de um músico
        [HttpGet("{musicoId}")]
        public async Task<IActionResult> GetDisponibilidadesDoMusico(int musicoId)
        {
            try
            {
                var disponibilidades = await _context.TB_MUSICO_DISPONIBILIDADE
                    .Where(md => md.MusicoId == musicoId)
                    .Include(md => md.disponibilidade)
                    .ToListAsync();

                return Ok(disponibilidades);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // DELETE: Remover associação via JSON no corpo
        [HttpDelete("remover")]
        public async Task<IActionResult> DeleteMusicoDisponibilidade([FromBody] MusicoDisponibilidade dados)
        {
            try
            {
                var associacao = await _context.TB_MUSICO_DISPONIBILIDADE
                    .FirstOrDefaultAsync(md => md.MusicoId == dados.MusicoId && md.DisponibilidadeId == dados.DisponibilidadeId);

                if (associacao == null)
                    return NotFound("Associação não encontrada.");

                _context.TB_MUSICO_DISPONIBILIDADE.Remove(associacao);
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