using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDePractica.BD.Data.Entity
{
    [Index(nameof(Codigo),Name = "TDocumento_UQ", IsUnique = true)]
    public class Titulo : EntityBase
    {
        [Required(ErrorMessage ="El codigo del TDocumento es obligatorio")]
        [MaxLength(4,ErrorMessage ="Maximo numero de caracteres {1}.")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El nombre del TDocumento es obligatorio")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Nombre { get; set; }
        public List<Profesion> Profesiones { get; set; }
    }
}
