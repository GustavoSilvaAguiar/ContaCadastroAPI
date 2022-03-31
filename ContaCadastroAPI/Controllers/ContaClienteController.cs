using AutoMapper;
using ContaCadastroAPI.Data;
using ContaCadastroAPI.Data.Dtos;
using ContaCadastroAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ContaCadastroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaClienteController : ControllerBase
    {
        private ContaContext _contaContext;
        private IMapper _mapper;

        public ContaClienteController(ContaContext context, IMapper mapper)
        {
            _contaContext = context;
            _mapper = mapper;
        }

        

        /// <summary>
        /// Preenchendo o banco de dados
        /// </summary>
        /// <param name="contaClienteDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AdicionarContaCliente([FromBody] CreateContaClienteDTO contaClienteDTO)
        {
            ContaCliente contaCliente = _mapper.Map<ContaCliente>(contaClienteDTO);
            _contaContext.ContasCliente.Add(contaCliente);
            _contaContext.SaveChanges();

            return CreatedAtAction(nameof(ConsultarContaClientePorId), new { Id = contaCliente.Id }, contaCliente);
        }

        /// <summary>
        /// Consultando tabela de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ConsultarContaCliente()
        {
            return Ok(_contaContext.ContasCliente);
        }

        /// <summary>
        /// Consulta conta pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public IActionResult ConsultarContaClientePorId(int id)
        {
            ContaCliente contaCliente = _contaContext.ContasCliente.FirstOrDefault(contaCliente => contaCliente.Id == id);

            if (contaCliente != null)
            {
                ReadContaClienteDTO readContaClienteDTO = _mapper.Map<ReadContaClienteDTO>(contaCliente);
                
                return Ok(readContaClienteDTO);
                
            }
            
            return NotFound();
        }

        /// <summary>
        /// Consulta conta pelo CNPJ
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        [HttpGet("cnpj/{cnpj}")]
        public IActionResult ConsultarContaClientePorId(string cnpj)
        {
            ContaCliente contaCliente = _contaContext.ContasCliente.FirstOrDefault(contaCliente => contaCliente.CNPJ == cnpj);

            if (contaCliente != null)
            {
                ReadContaClienteDTO readContaClienteDTO = _mapper.Map<ReadContaClienteDTO>(contaCliente);
                return Ok(readContaClienteDTO);
            }
            return NotFound();
        }

        /// <summary>
        /// Atualizar Com busca por CNPJ
        /// </summary>
        /// <param name="cnpj"></param>
        /// <param name="contaClienteNovaDTO"></param>
        /// <returns></returns>
        [HttpPut("cnpj/{cnpj}")]
        public IActionResult AtualizarContaClienteCNPJ(string cnpj, [FromBody] UpdateContaClienteDTO contaClienteNovaDTO)
        {  

            ContaCliente contaCliente = _contaContext.ContasCliente.FirstOrDefault(contaCliente => contaCliente.CNPJ == cnpj);

            if (contaCliente == null)
            {
                return NotFound();
            }
           
            _mapper.Map(contaClienteNovaDTO, contaCliente);
            _contaContext.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Atualizar por busca por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contaClienteNovaDTO"></param>
        /// <returns></returns>
        [HttpPut("id/{id}")]
        public IActionResult AtualizarConta(int id, [FromBody] UpdateContaClienteDTO contaClienteNovaDTO)
        {
            ContaCliente contaCliente = _contaContext.ContasCliente.FirstOrDefault(contaCliente => contaCliente.Id == id);
            if (contaCliente == null)
            {
                return NotFound();
            }
            _mapper.Map(contaClienteNovaDTO, contaCliente);
            _contaContext.SaveChanges();
            return NoContent();
        }
        
        /// <summary>
        /// Deletar por busca por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id/{id}")]
        public IActionResult ExcluirContaPorID(int id)
        {
            ContaCliente conta = _contaContext.ContasCliente.FirstOrDefault(conta => conta.Id == id);
            if (conta == null)
            {
                return NotFound();
            }
            _contaContext.Remove(conta);
            _contaContext.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Deletar por busca por CNPJ
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        [HttpDelete("cnpj/{cnpj}")]
        public IActionResult ExcluirContaPorCNPJ(string cnpj)
        {
            ContaCliente conta = _contaContext.ContasCliente.FirstOrDefault(conta => conta.CNPJ == cnpj);
            if (conta == null)
            {
                return NotFound();
            }
            _contaContext.Remove(conta);
            _contaContext.SaveChanges();
            return NoContent();
        }
    }
}
