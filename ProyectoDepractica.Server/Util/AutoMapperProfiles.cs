using AutoMapper;
using ProyectoDePractica.BD.Data.Entity;
using ProyectoDePractica.Shared.DTOs;

namespace ProyectoDepractica.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<TituloDTO, Titulo>();

        }
    }
}
