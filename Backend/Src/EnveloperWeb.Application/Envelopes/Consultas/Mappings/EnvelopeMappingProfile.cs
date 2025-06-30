using AutoMapper;
using EnveloperWeb.Application.Envelopes.Consultas.DTOs;
using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Envelopes.Filters;
using System.Linq;

namespace EnveloperWeb.Application.Envelopes.Consultas.Mappings
{
    public class EnvelopeMappingProfile : Profile
    {
        public EnvelopeMappingProfile()
        {
            CreateMap<Envelope, EnvelopeDetalhadoDto>()
                .ForMember(dest => dest.NomeClima, opt => opt.MapFrom(src => src.Clima.Nome))
                .ForMember(dest => dest.NomeTurno, opt => opt.MapFrom(src => src.Turno.Nome))
                .ForMember(dest => dest.Responsaveis, opt =>
                    opt.MapFrom(src => src.Responsaveis.Select(r => r.Usuario.Nome).ToList()));

            CreateMap<Envelope, EnvelopeResumoDto>()
                .ForMember(dest => dest.NomeTurno, opt => opt.MapFrom(src => src.Turno.Nome))
                .ForMember(dest => dest.NomeClima, opt => opt.MapFrom(src => src.Clima.Nome))
                .ForMember(dest => dest.Responsaveis, opt => 
                    opt.MapFrom(src => src.Responsaveis.Select(r => r.Usuario.Nome).ToList()));

            CreateMap<EnvelopeFiltroConsultaDto, EnvelopeFiltroConsulta>();
        }
    }
}
