using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAM_MB_API.Data;
using PAM_MB_API.Models;
using PAM_MB_API.Models.Enums;

namespace PAM_MB_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;
        public UsuariosController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                List<Usuario> lista = await _context.TB_USUARIO.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetUsuario(int usuarioId)
        {
            try
            {
                Usuario usuario = await _context.TB_USUARIO.FirstOrDefaultAsync(x => x.Id == usuarioId); //Busca o usuário no banco através do Id .FirstOrDefaultAsync(x => x.Id == usuarioId);
                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private async Task<bool> UsuarioExistente(string username)
        {
            if (await _context.TB_USUARIO.AnyAsync(x => x.Nome.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if (await UsuarioExistente(user.Nome))
                    throw new System.Exception("Nome de usuário já existe");
                await _context.TB_USUARIO.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
        [HttpPut("{id}")]
public async Task<IActionResult> AtualizarUsuario(int id, Usuario usuarioAtualizado)
{
    if (id != usuarioAtualizado.Id)
        return BadRequest("O ID informado na URL é diferente do corpo da requisição.");

    var usuarioExistente = await _context.TB_USUARIO.FindAsync(id);

    if (usuarioExistente == null)
        return NotFound("Usuário não encontrado.");
    usuarioExistente.Nome = usuarioAtualizado.Nome;
    usuarioExistente.Email = usuarioAtualizado.Email;
    usuarioExistente.Endereco = usuarioAtualizado.Endereco;
    usuarioExistente.Senha = usuarioAtualizado.Senha;
    usuarioExistente.Telefone = usuarioAtualizado.Telefone;
    usuarioExistente.Bio = usuarioAtualizado.Bio;
    usuarioExistente.DataCriacao = usuarioAtualizado.DataCriacao;
    usuarioExistente.FotoPerfil = usuarioAtualizado.FotoPerfil;

    try
    {
        await _context.SaveChangesAsync();
        return Ok(usuarioExistente);
    }
    catch (Exception ex)
    {
        return BadRequest($"Erro ao atualizar usuário: {ex.Message}");
    }
} 
    }
}