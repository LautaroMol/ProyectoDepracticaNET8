using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDePractica.BD.Data.Entity
{
    public class TDocumento : EntityBase
    {
        [Required(ErrorMessage = "Codigo obligatorio")]
        [MaxLength(8, ErrorMessage = "maximo numero de caracteres {1}")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Nombre obligatorio")]
        [MaxLength(100, ErrorMessage = "maximo numero de caracteres {1}")]
        public string Nombre { get; set; }

    }
}
