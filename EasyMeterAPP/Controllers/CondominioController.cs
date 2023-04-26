using EasyMeterAPP.DTO;
using EasyMeterAPP.Entities.Entity;
using EasyMeterAPP.InfraEstrutura.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyMeterAPP.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CondominioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CondominioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListarCondominios()
        {
            var condominios = await _context.CONDOMINIO.AsNoTracking().ToListAsync();
            List<CondominioDTO> condominiosDTO = new List<CondominioDTO>();
            CondominioDTO condominioDTO = null;

            foreach (var condominio in condominios)
            {
                condominioDTO = new CondominioDTO();

                condominioDTO.Id = condominio.Id;
                condominioDTO.Nome = condominio.Nome;
                condominiosDTO.Add(condominioDTO);
            }
            return condominiosDTO.Count == 0 ? NotFound("Condominios nao cadastradas") : Ok(condominiosDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarCondominiosAsync([FromBody] CondominioDTQ condominioQuery)
        {
            Condominio condominio = new Condominio();
            condominio.Id = condominioQuery.Id;
            condominio.Nome = condominioQuery.Nome;

            _context.CONDOMINIO.Add(condominio);
            await _context.SaveChangesAsync();

            return Ok(condominio);
        }




    }
}
