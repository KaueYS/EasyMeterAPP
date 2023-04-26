using EasyMeterAPP.DTO;
using EasyMeterAPP.Entities.Entity;
using EasyMeterAPP.InfraEstrutura.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyMeterAPP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UnidadeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUnidadesAsync(int blocoId)
        {
            var unidades = await _context.UNIDADE.Where(x => x.BlocoId == blocoId).ToListAsync();
            List<UnidadeDTO> unidadesDTO = new List<UnidadeDTO>();
            UnidadeDTO unidadeDTO = null;
            foreach (var unidade in unidades)
            {
                unidadeDTO = new UnidadeDTO();
                unidadeDTO.Id = unidade.Id;
                unidadeDTO.Nome = unidade.Nome;

                unidadesDTO.Add(unidadeDTO);
            }
            return unidadesDTO.Count == 0 ? NotFound("Unidades nao cadastradas") : Ok(unidadesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUnidadesAsync([FromBody] UnidadeDTQ unidadeQuery)
        {
            Unidade unidade = new Unidade();
            if (unidade is null) return NotFound();

            unidade.Id = unidadeQuery.Id;
            unidade.Nome = unidadeQuery.Nome;
            unidade.BlocoId = unidadeQuery.BlocoId;
            unidade.CondominioId = unidadeQuery.CondominioId;

            _context.UNIDADE.Add(unidade);
            await _context.SaveChangesAsync();

            return Ok(unidade);
        }
    }
}
