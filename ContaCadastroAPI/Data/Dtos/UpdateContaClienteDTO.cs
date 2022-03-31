using ContaCadastroAPI.Services;
using System.ComponentModel.DataAnnotations;

namespace ContaCadastroAPI.Data.Dtos
{
    public class UpdateContaClienteDTO
    {
        [Required]
        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        [Required]
        public string CNPJ { get; set; }
    }
}
