using AutoMapper;
using ProyectoDePractica.BD.Data.Entity;
using ProyectoDePractica.Shared.DTOs;

namespace ProyectoDepractica.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<EspecialidadDTO, Especialidad>();
            CreateMap<TituloDTO, Titulo>();
            CreateMap<ProfesionDTO, Profesion>();
            CreateMap<Matricula, MatriculaDTO>().ReverseMap();
            CreateMap<Especialidad, EspecialidadDTO>().ReverseMap();
            CreateMap<PersonaDTO, Persona>();

        }
    }
}
