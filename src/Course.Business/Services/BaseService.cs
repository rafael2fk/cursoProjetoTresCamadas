using Course.Business.Interfaces;
using Course.Business.Models;
using Course.Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace Course.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                Notificar(item.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) 
            where TV : AbstractValidator<TE>
            where TE : Entity   
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            // Lancamento de notificacoes
            Notificar(validator);

            return false;
        }
    }
}
