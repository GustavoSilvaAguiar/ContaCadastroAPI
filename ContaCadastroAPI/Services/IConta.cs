using System.ComponentModel.DataAnnotations;

namespace ContaCadastroAPI.Services
{
    interface IConta
    {
        public int Id { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }
    }
}
