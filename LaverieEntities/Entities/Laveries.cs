using System.Text.Json.Serialization;

namespace LaverieEntities.Entities
{
    public class Laveries
    {
        public int IdLaverie { get; set; }
        public string? CapaciteLaverie { get; set; }

        public string? AddresseLaverie { get; set; }

        public List<Machine> machinesLaverie { get; set; } = new List<Machine>();

        public int? ProprietaireCIN { get; set; }

        [JsonIgnore]
        public Proprietaire? Proprietaire { get; set; }
        public Laveries() { }
    }
}
