using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Reply : Entity
    {
        public string Content { get; set; }
        public User User { get; set; }
        public Comment Comment { get; set; }
    }
}
