using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Web.Models
{
   public class GuessingGameViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        [Display(Name = "Your Name")]
        public string Name { get; set; }

        [Required]
        [Range(1,10)]
        [Display(Name="Your Guess")]
        public int Guess { get; set; }

    }
}
