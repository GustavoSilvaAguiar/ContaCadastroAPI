using ContaCadastroAPI.Services;
using System.ComponentModel.DataAnnotations;

namespace ContaCadastroAPI.Data.Dtos
{
    public class ReadContaClienteDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        [Required]
        public string CNPJ { get; set; }
    }
}
