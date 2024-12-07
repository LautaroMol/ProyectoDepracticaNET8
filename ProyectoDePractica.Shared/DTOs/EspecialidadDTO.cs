using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDePractica.Shared.DTOs
{
    public class EspecialidadDTO
    {
        [Required(ErrorMessage = "El código de la especialidad es obligatorio.")]
        [MaxLength(4, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre de la especialidad es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Nombre { get; set; }
        public int TDocumentoId { get; set; }
    }
}
