using System.ComponentModel.DataAnnotations;
namespace GameZone.Api.ViewModels
{
    public class DeveloperViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string HeadQuarters { get; set; }
    }
}
