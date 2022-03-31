using ContaCadastroAPI.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContaCadastroAPI.Models
{
    public class ContaCliente : IConta
    {
        [Required]
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        [Required]
        public string CNPJ { get; set; }
        public int Id { get; set; }

        [JsonIgnore]
        public IList<ContaParceiro> ContasParceiro { get; set; }
    }
}
