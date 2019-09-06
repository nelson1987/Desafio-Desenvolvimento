using Desafio.Api.Contracts;
using Desafio.Domain.Applications;
using Desafio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MovimentoController : ControllerBase
    {
        // GET api/Fundo
        [HttpGet]
        public ActionResult<IEnumerable<Movimentacao>> Get([FromServices] IMovimentoApplication fundoApplication)
        {
            try
            {
                var fundos = fundoApplication.Listar();
                return fundos.ToList();
            }
            catch (Exception)
            {
                //TODO: Logar a exception
                return BadRequest("Erro ao listar Movimentos.");
            }
        }
    }
}
