using ContaCadastroAPI.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContaCadastroAPI.Models
{
    public class ContaParceiro : IConta
    {
        [Required]
        public string RazaoSocial { get; set; }


        public string NomeFantasia { get; set; }

        [Required]
        public string CNPJ { get; set; }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        
        public int ContaClienteId { get; set; }
        [JsonIgnore]
        public ContaCliente ContaCliente { get; set; }
    }
}
