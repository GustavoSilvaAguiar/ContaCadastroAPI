using AutoMapper;
using ContaCadastroAPI.Data.Dtos;
using ContaCadastroAPI.Models;

namespace ContaCadastroAPI.Adapters
{
    public class ContaParceiroAdapter : Profile
    {
        public ContaParceiroAdapter()
        {
            CreateMap<CreateParceiroClienteDTO, ContaParceiro>();
            CreateMap<UpdateContaParceiroDTO, ContaParceiro>();
            CreateMap<ContaParceiro, ReadContaParceiroDTO>();
        }
    }
}
