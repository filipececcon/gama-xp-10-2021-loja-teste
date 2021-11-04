using System;
using System.Linq;
using FluentValidation;
using Teste.Loja.Domain.Shared.Entities;
using Teste.Loja.Domain.Shared.Interfaces;
using Teste.Loja.Domain.Shared.Responses;

namespace Teste.Loja.Domain.Shared.Handlers
{
    public abstract class CommandHandler<TEntidade, TRequest, TResponse>
        where TEntidade : Entidade
        where TResponse : Response
    {
        protected readonly ICommandRepository<TEntidade> _repository;

        public abstract IValidator<TRequest> Validator { get; }

        protected TResponse _response { get; }

        public CommandHandler(ICommandRepository<TEntidade> repository)
        {
            _repository = repository;

            _response = Activator.CreateInstance<TResponse>();
        }

        private void ValidateRequest(TRequest request)
        {
            var errors = Validator.Validate(request).Errors;

            _response.SetErrorList(errors);
        }

        public TResponse Handle(TRequest request)
        {
            ValidateRequest(request);

            if (_response.Errors.Any()) return _response;

            BeforeChanges(request);

            if (_response.Errors.Any()) return _response;

            var entidade = Changes(request);

            _repository.Save();

            return AfterChanges(request, entidade);            
        }


        protected abstract void BeforeChanges(TRequest request);
            
        protected abstract TEntidade Changes(TRequest request);

        protected abstract TResponse AfterChanges(TRequest request, TEntidade entidade);
    }
}
