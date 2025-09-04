using API_Academia.BancoDados.Entidades;
using API_Academia.Data.DTOs;
using AutoMapper;

namespace API_Academia.Mapper
{
    public class ConfiguracaoMapeamento : Profile
    {
        ConfiguracaoMapeamento()
        {
            CreateMap<UsuarioEntidade, CreateUserDto>().ReverseMap();
            CreateMap<UsuarioEntidade, UserDto>().ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.Cargo.NomeCargo));
        }
    }
}
