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
       public async Task<ActionResult<IEnumerable<Musico>>> GetMusicos()
{
    return await _context.TB_MUSICOS
        .ToListAsync();
}

    }
}