using EasyMeterAPP.DTO;
using EasyMeterAPP.Entities.Entity;
using EasyMeterAPP.InfraEstrutura.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyMeterAPP.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BlocoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BlocoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListarBlocos(int condominioId)
        {
            var blocos = await _context.BLOCO.Where(x=> x.CondominioId == condominioId).ToListAsync();
            List<BlocoDTO> blocosDTO = new List<BlocoDTO>();
            BlocoDTO blocoDTO = null;
            foreach (var bloco in blocos)
            {
                blocoDTO = new BlocoDTO();
                blocoDTO.Id = bloco.Id;
                blocoDTO.Nome = bloco.Nome;

                blocosDTO.Add(blocoDTO);
            }
            return blocosDTO.Count == 0 ? NotFound("Blocos nao cadastradas") : Ok(blocosDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarBlocosAsync([FromBody] BlocoDTQ blocoQuery)
        {
            Bloco bloco = new Bloco();
            bloco.Id = blocoQuery.Id;
            bloco.Nome = blocoQuery.Nome;
            bloco.CondominioId = blocoQuery.CondominioId;
            _context.BLOCO.Add(bloco);
            await _context.SaveChangesAsync();


            return Ok(bloco);
        }


    }
}
