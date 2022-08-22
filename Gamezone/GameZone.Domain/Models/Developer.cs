namespace GameZone.Domain.Models
{
    public class Developer : Entity
    {
        public string Name { get; set; }
        public string Headquarters { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
