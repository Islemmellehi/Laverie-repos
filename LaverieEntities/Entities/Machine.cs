using LaverieEntities.Entities;
using System.Text.Json.Serialization;

namespace LaverieEntities.Entities
{
    public class Machine
    {
        public int IdMachine { get; set; }
        public string MarqueMachine { get; set; }

        public string EtatMachine { get; set; }
        public List<Cycle> cyclesMachine { get; set; } = new List<Cycle>();


        public int? IDLaverie { get; set; }

        [JsonIgnore]
        public Laveries? Laverie { get; set; }

        public Machine() { }
    }
}
