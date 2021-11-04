using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste.Loja.Domain.Core.Commands;
using Teste.Loja.Domain.Core.Entities;
using Teste.Loja.Domain.Core.Queries;
using Teste.Loja.Domain.Core.Requests;
using Teste.Loja.Domain.Shared.Interfaces;
using Teste.Loja.Infra.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste.Loja.API.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly AddProdutoCommandHandler _add;
        private readonly UpdateProdutoCommandHandler _update;
        private readonly GetProdutoQueryHandler _query;

        public ProdutoController(ICommandRepository<Produto> command, IQueryRepository<Produto> query)
        {
            _add = new AddProdutoCommandHandler(command);
            _update = new UpdateProdutoCommandHandler(command);
            _query = new GetProdutoQueryHandler(query);
        }

        [HttpGet]
        public IActionResult GetProduto([FromQuery] GetProdutoRequest request)
        {
            request.Id = null;

            var result = _query.Handle(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProduto([FromRoute] Guid id)
        {
            var request = new GetProdutoRequest() { Id = id };

            var result = _query.Handle(request).First();

            return Ok(result);
        }


        [HttpPost]
        public IActionResult Add([FromBody] AddProdutoRequest request)
        {
            try
            {
                var response = _add.Handle(request);

                var url = $"http://localhost:55429/api/produto/{response.Id}";

                return Created(url, response);
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateProdutoRequest request)
        {
            try
            {
                request.Id = id;

                var response = _update.Handle(request);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}
