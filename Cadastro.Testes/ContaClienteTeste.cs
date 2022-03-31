using ContaCadastroAPI.Controllers;
using ContaCadastroAPI.Data.Dtos;
using System;
using Xunit;

namespace Cadastro.Testes
{
    public class ContaClienteTeste
    {
        [Fact]
        public void TestarPost()
        {
            ContaClienteController conta = new ContaClienteController();

            string url = 
            //conta.AdicionarContaCliente([FromBody] CreateContaClienteDTO contaClienteDTO);
        }
    }
}
