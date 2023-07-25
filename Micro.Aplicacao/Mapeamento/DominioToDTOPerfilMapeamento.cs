using AutoMapper;
using Micro.Aplicacao.DTOs;
using Micro.Dominio.Entidades;

public class DominioToDTOPerfilMapeamento : Profile 
{
    public DominioToDTOPerfilMapeamento()
    {
        CreateMap<Programas, ProgramaDTO>().ReverseMap();

    }
}
