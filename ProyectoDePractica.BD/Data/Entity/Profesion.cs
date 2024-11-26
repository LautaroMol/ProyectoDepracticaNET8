using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDePractica.BD.Data.Entity
{
    public class Profesion : EntityBase
    {
        [Required(ErrorMessage = "La persona es obligatoria")]
        public int PersonaId {  get; set; }
        public Persona Persona { get; set; }
        [Required(ErrorMessage = "El TDocumento es obligatorio")]
        public int TDocumentoId { get; set; }
        public TDocumento TDocumento { get; set; }
    }
}
