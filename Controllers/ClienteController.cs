using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoLojaEF.Dados;
using BancoLojaEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace BancoLojaEF.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {

        Cliente cliente = new Cliente();
        readonly LojaContexto contexto;


        public ClienteController(LojaContexto contexto)
        {
            this.contexto = contexto;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return contexto.Cliente.ToList();
        }

        // GET api/values/5
        [HttpGet("{Id}")]
        public Cliente Get(int Id)
        {
            return contexto.Cliente.Where(x => x.IdCliente == Id).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            contexto.Cliente.Add(cliente);
            int x = contexto.SaveChanges();
            if (x > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody]Cliente cliente)
        {
            if (cliente == null || cliente.IdCliente != Id)
            {
                return BadRequest();
            }

            var cli = contexto.Cliente.Where(c => c.IdCliente == Id).FirstOrDefault();
            if (cli == null)
            {
                return NotFound();
            }

            cli.Nome = cliente.Nome;
            cli.Email = cliente.Email;
            cli.Idade = cliente.Idade;

            contexto.Cliente.Update(cli);
            int x = contexto.SaveChanges();
            if (x > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var cliente = contexto.Cliente.Where(ci => ci.IdCliente == Id).FirstOrDefault();
            if (cliente == null)
            {
                return NotFound();
            }

            contexto.Cliente.Remove(cliente);
            int x = contexto.SaveChanges();
            if (x > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
