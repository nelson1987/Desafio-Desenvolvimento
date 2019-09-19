using Desafio.Api.Contracts;
using Desafio.Domain.Applications;
using Desafio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        // GET api/Fundo
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<Pessoa>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<Pessoa>> Get([FromServices] IPessoaApplication fundoApplication)
        {
            try
            {
                var fundos = fundoApplication.Listar();
                return fundos.ToList();
            }
            catch (Exception)
            {
                //TODO: Logar a exception
                return BadRequest("Erro ao listar Fundos.");
            }
        }
    }
}
