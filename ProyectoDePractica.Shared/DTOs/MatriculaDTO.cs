using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDePractica.Shared.DTOs
{
    public class MatriculaDTO
    {
        [Required(ErrorMessage = "La Profesion es obligatoria.")]
        public int ProfesionId { get; set; }

        [Required(ErrorMessage = "La Especialidad es obligatoria.")]
        public int EspecialidadId { get; set; }

        [Required(ErrorMessage = "El Número de matrícula es obligatorio.")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Numero { get; set; }
    }
}
