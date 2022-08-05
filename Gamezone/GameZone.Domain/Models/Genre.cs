using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Genre : Entity
    {
        private static int serial = 1;
        public string Name { get; set; }
        public Genre(string name)
        {
            this.Name = name;
            this.Id = serial++;
        }
    }
}

