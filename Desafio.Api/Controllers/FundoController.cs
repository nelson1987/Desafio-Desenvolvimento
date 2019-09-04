using Desafio.Domain.Applications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
                return new string[] { "value1", "value2" };
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return BadRequest("Erro ao listar Fundos.");
            }
        }
    }
}
