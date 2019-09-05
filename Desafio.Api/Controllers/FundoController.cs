using Desafio.Domain.Applications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundoController : ControllerBase
    {
        // GET api/Fundo
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromServices] IFundoApplication fundoApplication)
        {
            try
            {
                var fundos = fundoApplication.Listar();
                return fundos.Select(x => x.Nome).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao listar Fundos.");
            }
        }
    }
}
