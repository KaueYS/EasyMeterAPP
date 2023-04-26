using EasyMeterAPP.Entities.Entity;
using System.Text.Json.Serialization;

namespace EasyMeterAPP.DTO
{
    public class UnidadeDTQ
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int? BlocoId { get; set; }

        public int CondominioId { get; set; }



        //[JsonIgnore]
        //public Bloco Bloco { get; set; }
        //[JsonIgnore]
        //public Condominio Condominio { get; set; }
    }
}
