using AutoMapper;
using ContaCadastroAPI.Data.Dtos;
using ContaCadastroAPI.Models;

namespace ContaCadastroAPI.Adapters
{
    public class ContaClienteAdapter : Profile
    {
        public ContaClienteAdapter()
        {
            CreateMap<CreateContaClienteDTO, ContaCliente>();
            CreateMap<UpdateContaClienteDTO, ContaCliente>();
            CreateMap<ContaCliente, ReadContaClienteDTO>();
        }
    }
}
