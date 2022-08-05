using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Platform : Entity
    {
        private static int serial = 1;
        public string Name { get; set; }
        public Platform(string name)
        {
            this.Name = name;
            this.Id = serial++;
        }
    }
}
