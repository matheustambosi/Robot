using FluentValidation;
using FluentValidation.Results;
using Robot.Core.Enums;
using Robot.Core.FluentValidation.Base;
using Robot.Core.Messaging.Request;
using Robot.Core.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Robot.Core.FluentValidation.Validations
{
    public class MovimentarCabecaValidation : AbstractValidatorBase<MovimentarCabecaRequest>
    {
        public override Task<ValidationResult> ValidateAsync(ValidationContext<MovimentarCabecaRequest> context, CancellationToken cancellation = default)
        {
            RuleFor(request => request)
                .Must(request => Validacoes.ProximoEstadoValido(request.EstadoAtual, request.ProximoEstado))
                    .WithMessage("O próximo estado deve ser subsequente ao estado atual.");

            //VALIDAR LIMITES
            When(request => request.Direcao == Direcao.Horizontal, () => RuleFor(request => request));

            return Validator(context, cancellation);
        }
    }
}
