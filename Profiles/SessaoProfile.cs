using AutoMapper;
using CS_API_WEB.Data.Dtos;
using CS_API_WEB.Models;

namespace CS_API_WEB.Profiles;

public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();
        CreateMap<Sessao, ReadSessaoDto>();
    }
}
