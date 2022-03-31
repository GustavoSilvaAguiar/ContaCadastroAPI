using ContaCadastroAPI.Data;
using ContaCadastroAPI.Models;
using System;
using Xunit;

namespace TestProject1
{
    public class Teste1
    {
        [Fact]
        public void GetContaCliente()
        {
            //Arrange

            //string razaoSocialT = "Teste";
            //string nomeFantasiaT = "TesteFantasia";
            //string cnpjT = "123Teste";

            var contexto = new ContaContext(3213213);
            bool conectado;

            //Act
            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch
            {
                throw new Exception("Não foi possivel conectar a base de dados");
            }



           //var cliente = new ContaCliente()
           //{
           //    CNPJ = cnpjT,
           //    RazaoSocial = razaoSocialT,
           //    NomeFantasia = nomeFantasiaT,
           //};

            //Assert
            Assert.True(conectado);

            //Assert.NotNull(cliente);
        }
    }
}
