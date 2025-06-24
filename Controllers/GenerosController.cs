using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAM_MB_API.Models;
using PAM_MB_API.Data; 

namespace PAM_MB_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : ControllerBase
    {
        private readonly DataContext _context;

        public GenerosController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> GetGeneros()
        {
            var generos = await _context.TB_GENERO.ToListAsync();
            return Ok(generos);
        }
    }
}
