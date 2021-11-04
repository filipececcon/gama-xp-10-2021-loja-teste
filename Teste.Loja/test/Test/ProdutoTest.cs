using System;
using System.Linq;
using Teste.Loja.Domain.Core.Commands;
using Teste.Loja.Domain.Core.Entities;
using Teste.Loja.Domain.Core.Requests;
using Teste.Loja.Domain.Shared.Interfaces;
using Teste.Loja.Infra.Data;
using Teste.Loja.Infra.Data.Repositories;
using Xunit;

namespace Test.Loja.Test
{
    public class ProdutoTest
    {
        private ICommandRepository<Produto> _repository;

        public ProdutoTest()
        {
            var context = new MercadoContext("Server=localhost;Database=MercadoDb;User Id=sa;Password=yourStrong(!)Password;");

            //_repository = new CommandRepository<Produto>(context);

            _repository = new Moq.Mock<ICommandRepository<Produto>>().Object;
        }


        [Fact]
        public void DeveRetornarErroAoAdicionarUmProdutoExistente()
        {
            Assert.True(false);
        }

        [Fact]
        public void DeveAdicionarUmProdutoComSucesso()
        {
            Assert.True(false);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("    ")]
        public void DeveRetornarErroAoAdicionarUmProdutoComONomeInvalido(string nomeInvalido)
        {
            var handler = new AddProdutoCommandHandler(_repository);

            var request = new AddProdutoRequest()
            {
                Nome = nomeInvalido,
                ValorUnitario = 10
            };
                        
            var response = handler.Handle(request);

            var isMensagemCorreta = response.Errors.Any(x => x == "'Nome' must not be empty.");

            Assert.True(isMensagemCorreta);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        public void DeveRetornarErroAoAdicionarUmProdutoComOPrecoInvalido(decimal valorInvalido)
        {
            var handler = new AddProdutoCommandHandler(_repository);

            var request = new AddProdutoRequest()
            {
                Nome = "nomevalido",
                ValorUnitario = valorInvalido
            };

            var response = handler.Handle(request);

            var mensagens = new string[]
            {
                "'Valor Unitario' must not be empty.",
                "'Valor Unitario' must be greater than '0'."
            };
            
            var isMensagemCorreta = response.Errors.Any(x => mensagens.Contains(x));

            Assert.True(isMensagemCorreta);
        }

        // RGR => Red, Green, Refactor



    }
}
