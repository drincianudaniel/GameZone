using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Developer : Entity
    {
        private static int serial = 1;
        public string Name { get; set; }

        public string Headquarters { get; set; }
        public Developer(string name, string headquarters)
        {
            this.Name = name;
            this.Headquarters = headquarters;
            this.Id = serial++;
        }
    }
}
