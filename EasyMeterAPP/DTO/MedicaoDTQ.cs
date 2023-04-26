namespace EasyMeterAPP.DTO
{
    public class MedicaoDTQ
    {
        public int Id { get; set; }
        public string? Prefixo { get; set; }
        public decimal MedicaoAtual { get; set; }
        public DateTime DataHoraMedicao { get; set; }
        public int UnidadeId { get; set; }
    }
}
