using EasyMeterAPP.DTO;
using EasyMeterAPP.Entities.Entity;
using EasyMeterAPP.InfraEstrutura.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aspose.OCR;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


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

        [HttpPost]
        public async Task<IActionResult> CastrarMedicaoImagem(IFormFile formFile)
        {
            //AsposeOcr asposeOcr = new AsposeOcr();
            //RecognitionResult recognitionResult = asposeOcr.RecognizeImage(Directory.GetCurrentDirectory() + @"\Imagens\teste.png", new RecognitionSettings { });
            
            var result = await ReadFileLocal(formFile, Directory.GetCurrentDirectory() + @"\Imagens\teste2.png");
            return Ok(result);
        }



        private async Task<IList<ReadResult>> ReadFileLocal(IFormFile formFile, string localFile)
        {
            ComputerVisionClient client = new ComputerVisionClient(new ApiKeyServiceClientCredentials("fedb7c51624a47fbb9898f98a42eeedb")) { Endpoint = "https://kaueysocrimagetext.cognitiveservices.azure.com/" };

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("READ FILE FROM LOCAL");
            Console.WriteLine();

            // Read text from URL
            //var textHeaders = await client.ReadInStreamAsync(System.IO.File.OpenRead(localFile));

            var textHeaders = await client.ReadInStreamAsync(formFile.OpenReadStream());


            // After the request, get the operation location (operation ID)
            string operationLocation = textHeaders.OperationLocation;
            Thread.Sleep(2000);

            // <snippet_extract_response>
            // Retrieve the URI where the recognized text will be stored from the Operation-Location header.
            // We only need the ID and not the full URL
            const int numberOfCharsInOperationId = 36;
            string operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);

            // Extract the text
            ReadOperationResult results;
            Console.WriteLine($"Reading text from local file {Path.GetFileName(localFile)}...");
            Console.WriteLine();
            do
            {
                results = await client.GetReadResultAsync(Guid.Parse(operationId));
            }
            while ((results.Status == OperationStatusCodes.Running ||
                results.Status == OperationStatusCodes.NotStarted));
            // </snippet_extract_response>

            // <snippet_extract_display>
            // Display the found text.
            Console.WriteLine();
            return results.AnalyzeResult.ReadResults;




            //foreach (ReadResult page in textUrlFileResults)
            //{
            //    foreach (Line line in page.Lines)
            //    {
            //        Console.WriteLine(line.Text);
            //    }
            //}
            //Console.WriteLine();
        }
        /*
         * END - READ FILE - LOCAL
         */
        // </snippet_read_local>
    }
}

