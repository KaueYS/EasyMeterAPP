using EasyMeterAPP.DTO;
using EasyMeterAPP.Entities.Entity;
using EasyMeterAPP.InfraEstrutura.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyMeterAPP.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MedicaoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MedicaoController(AppDbContext context)
        {
            _context = context;
        }

        //FLUXO e VERBOS sempre INICIAM na tela do USUARIO - quem faz o GET é o usuario, quem faz o POST é o usuario
        //Fluxo: Do Banco PARA Tela do usuario - via DTO
        [HttpGet]
        public async Task<IActionResult> ListarMedicoes()
        {
            var medicoes = await _context.MEDICAO.AsNoTracking().ToListAsync();
            List<MedicaoDTO> medicoesDTO = new List<MedicaoDTO>();
            MedicaoDTO medicaoDTO = null;
            foreach (var medicao in medicoes)
            {
                medicaoDTO = new MedicaoDTO();
                medicaoDTO.Id= medicao.Id;
                medicaoDTO.MedicaoAtual = medicao.MedicaoAtual;
                medicaoDTO.DataHoraMedicao = medicao.DataHoraMedicao;

                medicoesDTO.Add(medicaoDTO);
            }
            return medicoesDTO.Count == 0 ? NotFound("Medições não cadastradas") : Ok(medicoesDTO);
        }


        //Fluxo: Da Tela do usuario PARA o banco - via DTQ
        [HttpPost]
        public IActionResult CadastrarMedicao([FromBody] MedicaoSalvarDTQ medicaoSalvarQuery)
        {
            Medicao medicao = new Medicao();
            if (medicao is null) return NotFound();
            medicao.UnidadeId = medicaoSalvarQuery.UnidadeId;
            medicao.MedicaoAtual = medicaoSalvarQuery.MedicaoRealizada;
            medicao.DataHoraMedicao = medicaoSalvarQuery.DataHoraRealizada;

            _context.MEDICAO.Add(medicao);
            _context.SaveChanges();

            return Ok(medicao);
        }
    }
}
