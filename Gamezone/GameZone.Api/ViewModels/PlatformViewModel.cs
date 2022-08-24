using System.ComponentModel.DataAnnotations;
namespace GameZone.Api.ViewModels
{
    public class PlatformViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
