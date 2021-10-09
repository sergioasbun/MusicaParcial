using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicaParcial.Models
{
    public class Cancion
    {
        [Key]
        public String Nombre { get; set; }
        [Required]
        public String Autor { get; set; }
        [Required]
        public String Letra { get; set; }
        [Required]
        public String EnlaceYT { get; set; }
    }
}
