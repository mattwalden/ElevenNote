using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
   public class OkToDelete
    {
        [Key]
        public string SomeColumn { get; set; }
        public string SomeOtherColumn { get; set; }
        public string OneMoreColumn { get; set; }

        
    }
}
