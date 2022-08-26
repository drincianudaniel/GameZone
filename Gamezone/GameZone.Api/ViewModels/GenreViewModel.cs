using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace GameZone.Api.ViewModels
{
    public class GenreViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
