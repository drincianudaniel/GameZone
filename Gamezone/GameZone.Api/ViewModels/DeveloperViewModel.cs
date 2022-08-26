using System.ComponentModel.DataAnnotations;
namespace GameZone.Api.ViewModels
{
    public class DeveloperViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string HeadQuarters { get; set; }
    }
}
