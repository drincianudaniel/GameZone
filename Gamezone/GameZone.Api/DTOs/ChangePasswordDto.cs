using System.ComponentModel.DataAnnotations;

namespace GameZone.Api.DTOs
{
    public class ChangePasswordDto
    {
        [Required]
        [MaxLength(50)]
        public string OldPassword { get; set; }

        [Required]
        [MaxLength(50)]
        public string NewPassword { get; set; }
    }
}
