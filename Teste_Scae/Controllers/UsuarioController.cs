using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Teste_Scae.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        private readonly context.BancoDados _banco;

        public UsuarioController(context.BancoDados banco)
        {
            _banco = banco;
        }

        // GET: api/Usuario
        [HttpGet]
        public IActionResult Get()
        {
            try {
                return Ok(_banco.Usuario.ToList());
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var usuarioAtual = _banco.Usuario.Where(c => c.id == id).FirstOrDefault();
                if (usuarioAtual == null)
                    return NotFound();
                else
                    return Ok(usuarioAtual);
               
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        
        // POST: api/Usuario
        [HttpPost]
        public IActionResult Post([FromBody]Models.Usuarios usuario)
        {
            try
            {
                _banco.Usuario.Add(usuario);
                _banco.SaveChanges();
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        
        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Models.Usuarios usuario)
        {
            try
            {
                var usuarioAtual = _banco.Usuario.Where(c => c.id == id).FirstOrDefault();
                if (usuarioAtual == null)
                    return NotFound();
                else
                {
                    usuarioAtual.nome = usuario.nome;
                    usuarioAtual.end = usuario.end;
                    _banco.Update(usuarioAtual);
                    _banco.SaveChanges();
                }
                return Ok();
                   
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var usuarioAtual = _banco.Usuario.Where(c => c.id == id).FirstOrDefault();
                if (usuarioAtual == null)
                    return NotFound();
                else
                {
                    _banco.Remove(usuarioAtual);
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
