using AutoMapper;
using Desafio.Api.Contracts;
using Desafio.Api.Contracts.Movimento;
using Desafio.Api.Contracts.Movimento.Desafio.Api.Contracts.Movimento;
using Desafio.Domain.Applications;
using Desafio.Domain.Entities;
using Desafio.Domain.Exceptions;
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
        // GET api/Movimento
        [HttpGet]
        public ActionResult<IEnumerable<ListagemMovimentacaoFundoViewModel>> Get([FromServices] IMovimentoApplication application,
            [FromServices] IMapper mapper)
        {
            try
            {
                var movimentos = application.Listar();
                return mapper.Map<List<ListagemMovimentacaoFundoViewModel>>(movimentos);
            }
            catch (Exception)
            {
                //TODO: Logar a exception
                return BadRequest("Erro ao listar Fundos.");
            }
        }

        // GET api/Movimento
        [HttpPost]
        public ActionResult Post([FromServices] IMovimentoApplication application,
            [FromServices] IMapper mapper,
            [FromBody] InclusaoMovimentacaoFundoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var movimentacao = mapper.Map<Movimentacao>(model);

                    if (model.TipoMovimentacao == TipoMovimentoFundoViewModel.Aplicacao)
                        application.Resgatar(movimentacao);
                    else
                        application.Aplicar(movimentacao);

                    var movimento = model.TipoMovimentacao == TipoMovimentoFundoViewModel.Aplicacao ? "Aplicação" : "Resgate";
                    return Ok($"{movimento} realizado com sucesso.");
                }
                catch (DomainServiceException ex)
                {
                    return StatusCode(500, ex);
                }
                catch (Exception)
                {
                    //TODO: Logar a exception
                    return StatusCode(500, "Erro ao incluir movimento no fundo.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
