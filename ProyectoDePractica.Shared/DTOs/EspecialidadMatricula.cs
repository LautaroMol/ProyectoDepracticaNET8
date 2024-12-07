using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDePractica.Shared.DTOs
{
    public class EspecialidadMatricula
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public List<MatriculaDTO> Matriculas { get; set; } = new List<MatriculaDTO>();
    }
}
