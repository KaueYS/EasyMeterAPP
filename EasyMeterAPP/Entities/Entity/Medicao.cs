using System.Text.Json.Serialization;

namespace EasyMeterAPP.Entities.Entity
{
    public class Medicao
    {
        public int Id { get; set; }
        public string? Prefixo { get; set; }
        public decimal MedicaoAtual { get; set; }
        public DateTime DataHoraMedicao { get; set; }


        public int UnidadeId { get; set; }

        [JsonIgnore]
        public Unidade Unidade { get; set; }
    }
}
