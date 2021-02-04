using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teste_Scae.Controllers
{
    [Produces("application/json")]
    [Route("api/Endereco")]
    public class EnderecoController : Controller
    {
        private readonly context.BancoDados _banco;

        public EnderecoController(context.BancoDados banco)
        {
            _banco = banco;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_banco.Endereco.ToList());
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }

        
        [HttpGet("{idEnd}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var enderecoAtual = _banco.Endereco.Where(c => c.idEnd == id).FirstOrDefault();
                if (enderecoAtual == null)
                    return NotFound();
                else
                    return Ok(enderecoAtual);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        
        [HttpPost]
        public IActionResult Post([FromBody]Models.Enderecos endereco)
        {
            try
            {
                _banco.Endereco.Add(endereco);
                _banco.SaveChanges();
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        
        [HttpPut("{idEnd}")]
        public IActionResult Put(int id, [FromBody]Models.Enderecos endereco)
        {
            try
            {
                var enderecoAtual = _banco.Endereco.Where(c => c.idEnd == id).FirstOrDefault();
                if (enderecoAtual == null)
                    return NotFound();
                else
                {
                    
                    enderecoAtual.end = endereco.end;
                    _banco.Update(enderecoAtual);
                    _banco.SaveChanges();
                }
                return Ok();

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

       
        [HttpDelete("{idEnd}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var enderecoAtual = _banco.Endereco.Where(c => c.idEnd == id).FirstOrDefault();
                if (enderecoAtual == null)
                    return NotFound();
                else
                {
                    _banco.Remove(enderecoAtual);
                    _banco.SaveChanges();
                }
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
