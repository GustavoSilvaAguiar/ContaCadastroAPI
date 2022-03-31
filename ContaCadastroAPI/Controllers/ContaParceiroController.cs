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
    public class ContaParceiroController : ControllerBase
    {
        private ContaContext _contaContext;
        private IMapper _mapper;

        public ContaParceiroController(ContaContext context, IMapper mapper)
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
        public IActionResult AdicionarContaParceiro([FromBody] CreateParceiroClienteDTO contaParceiroDTO)
        {
            ContaParceiro contaParceiro = _mapper.Map<ContaParceiro>(contaParceiroDTO);
            _contaContext.ContasParceiro.Add(contaParceiro);
            _contaContext.SaveChanges();

            return CreatedAtAction(nameof(ConsultarContaParceiroPorId), new { Id = contaParceiro.Id }, contaParceiro);
        }

        /// <summary>
        /// Consultando tabela de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ConsultarContaParceiro()
        {
            return Ok(_contaContext.ContasParceiro);
        }

        /// <summary>
        /// Consulta conta pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public IActionResult ConsultarContaParceiroPorId(int id)
        {
            ContaParceiro contaParceiro = _contaContext.ContasParceiro.FirstOrDefault(contaParceiro => contaParceiro.Id == id);

            if (contaParceiro != null)
            {
                ReadContaParceiroDTO readContaParceiroDTO = _mapper.Map<ReadContaParceiroDTO>(contaParceiro);
                return Ok(readContaParceiroDTO);

            }
            return NotFound();
        }

        /// <summary>
        /// Consulta conta pelo CNPJ
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        [HttpGet("cnpj/{cnpj}")]
        public IActionResult ConsultarContaParceiroPorId(string cnpj)
        {
            ContaParceiro contaParceiro = _contaContext.ContasParceiro.FirstOrDefault(contaParceiro => contaParceiro.CNPJ == cnpj);

            if (contaParceiro != null)
            {
                ReadContaParceiroDTO readContaParceiroDTO = _mapper.Map<ReadContaParceiroDTO>(contaParceiro);
                return Ok(readContaParceiroDTO);
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
        public IActionResult AtualizarContaParceiroCNPJ(string cnpj, [FromBody] UpdateContaParceiroDTO contaParceiroNovaDTO)
        {

            ContaParceiro contaParceiro = _contaContext.ContasParceiro.FirstOrDefault(contaParceiro => contaParceiro.CNPJ == cnpj);

            if (contaParceiro == null)
            {
                return NotFound();
            }

            _mapper.Map(contaParceiroNovaDTO, contaParceiro);
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
        public IActionResult AtualizarConta(int id, [FromBody] UpdateContaParceiroDTO contaParceiroNovaDTO)
        {
            ContaParceiro contaParceiro = _contaContext.ContasParceiro.FirstOrDefault(contaParceiro => contaParceiro.Id == id);
            if (contaParceiro == null)
            {
                return NotFound();
            }
            _mapper.Map(contaParceiroNovaDTO, contaParceiro);
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
            ContaParceiro conta = _contaContext.ContasParceiro.FirstOrDefault(conta => conta.Id == id);
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
            ContaParceiro conta = _contaContext.ContasParceiro.FirstOrDefault(conta => conta.CNPJ == cnpj);
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
