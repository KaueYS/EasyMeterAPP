using System.Text.Json.Serialization;

namespace EasyMeterAPP.Entities.Entity
{
    public class Bloco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CondominioId { get; set; }

        [JsonIgnore]
        public Condominio Condominio { get; set; }
    }
}
