using LaverieEntities.Entities;

namespace LaverieEntities.Entities
{
    public class Proprietaire
    {
        public int _CIN { get; set; }
        public string _Surname { get; set; }


        public List<Laveries> propLaverie { get; set; } = new List<Laveries>();

        public Proprietaire() { }
    }
}
