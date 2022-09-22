using System.ComponentModel.DataAnnotations;

namespace GameZone.Api.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
