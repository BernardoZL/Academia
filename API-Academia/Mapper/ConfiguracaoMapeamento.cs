using API_Academia.BancoDados.Entidades;
using API_Academia.Data.DTOs;
using API_Academia.Data.Models;
using AutoMapper;

namespace API_Academia.Mapper
{
    public class ConfiguracaoMapeamento : Profile
    {
        public ConfiguracaoMapeamento()
        {
            #region Usuario
            CreateMap<UsuarioEntidade, CreateUserDto>().ReverseMap();
            CreateMap<UsuarioEntidade, UsuarioToken>().ReverseMap();
            CreateMap<UsuarioEntidade, UserDto>().ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.Cargo.NomeCargo));

            #endregion Usuario

            #region Avaliacao Fisica
            CreateMap<AvaliacaoFisicaEntidade, AvaliacaoFisicaDTO>().ReverseMap();

            #endregion Avaliacao Fisica

            #region Treino
            CreateMap<TreinoEntidade, TreinoDTO>().ReverseMap();

            #endregion Treino
        }


    }
}
