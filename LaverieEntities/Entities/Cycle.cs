using System.Text.Json.Serialization;

namespace LaverieEntities.Entities
{
    public class Cycle
    {
        public int IdCycle { get; set; }
        public string NomCycle { get; set; }
        public int DureeCycleHR { get; set; }

        public double coutCycle { get; set; }
        public int? IdMachine { get; set; }

        [JsonIgnore]
        public Machine? Machine { get; set; }
        public Cycle() { }
    }
}
