namespace Altalents.IBusiness.Models
{
    public class LieuModel : IEquatable<LieuModel>
    {
        public Guid Id { get; set; }
        public string Libelle { get; set; }
        public string LibelleTransLit { get; set; }
        public int Ordre { get; set; }

        public bool Equals(LieuModel other)
        {
            return Id == other.Id && Libelle.Equals(other.Libelle);
        }
    }
}
