using System.ComponentModel.DataAnnotations;

namespace GameZone.Api.DTOs
{
    public class UserPatchDto
    {
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
