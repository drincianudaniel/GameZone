using System.ComponentModel.DataAnnotations;
namespace GameZone.Api.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddressAttribute]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [UrlAttribute]
        public string ProfileImageSrc { get; set; }

    }
}
