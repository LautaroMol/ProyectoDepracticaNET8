using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDePractica.Shared.DTOs
{
    public class ProfesionDTO
    {
        [Required(ErrorMessage = "La persona es obligatoria")]
        public int PersonaId { get; set; }
        [Required(ErrorMessage = "El TDocumento es obligatorio")]
        public int TDocumentoId { get; set; }
    }
}
