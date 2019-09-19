using AutoMapper;
using Desafio.Api.Contracts.Fundo;
using Desafio.Domain.Applications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FundoController : ControllerBase
    {
        private readonly ILogger _logger;

        public FundoController(ILogger<FundoController> logger)
        {
            _logger = logger;

        }
        // GET api/Fundo
        [HttpGet]
        public ActionResult<IEnumerable<ListagemFundoViewModel>> Get([FromServices] IFundoApplication application,
            [FromServices] IMapper mapper)
        {
            _logger.LogInformation("Log message in the Index() method");
            try
            {
                return mapper.Map<List<ListagemFundoViewModel>>(application.Listar());
            }
            catch (Exception)
            {
                //TODO: Logar a exception
                return BadRequest("Erro ao listar Fundos.");
            }
        }
    }
}
