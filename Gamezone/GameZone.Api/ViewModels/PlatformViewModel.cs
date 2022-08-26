using System.ComponentModel.DataAnnotations;
namespace GameZone.Api.ViewModels
{
    public class PlatformViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
