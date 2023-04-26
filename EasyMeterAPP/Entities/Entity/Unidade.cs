using System.Text.Json.Serialization;

namespace EasyMeterAPP.Entities.Entity
{
    public class Unidade
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int? BlocoId { get; set; }

        public int CondominioId { get; set; }

        
        
        [JsonIgnore]
        public Bloco Bloco { get; set;}
        [JsonIgnore]
        public Condominio Condominio { get; set;}

    }
}
