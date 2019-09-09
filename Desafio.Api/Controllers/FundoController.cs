using AutoMapper;
using Desafio.Api.Contracts.Fundo;
using Desafio.Domain.Applications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FundoController : ControllerBase
    {
        // GET api/Fundo
        [HttpGet]
        public ActionResult<IEnumerable<ListagemFundoViewModel>> Get([FromServices] IFundoApplication application,
            [FromServices] IMapper mapper)
        {
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
