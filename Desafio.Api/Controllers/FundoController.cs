﻿using Desafio.Api.Contracts;
using Desafio.Domain.Applications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FundoController : ControllerBase
    {
        // GET api/Fundo
        [HttpGet]
        public ActionResult<IEnumerable<ListagemFundosDataTransfer>> Get([FromServices] IFundoApplication fundoApplication)
        {
            try
            {
                var fundos = fundoApplication.Listar();
                return fundos.Select(x => new ListagemFundosDataTransfer(x)).ToList();
            }
            catch (Exception)
            {
                //TODO: Logar a exception
                return BadRequest("Erro ao listar Fundos.");
            }
        }
    }
}
