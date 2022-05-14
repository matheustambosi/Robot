using FluentValidation;
using FluentValidation.Results;
using Robot.Core.Enums;
using Robot.Core.FluentValidation.Base;
using Robot.Core.Messaging.Services;
using Robot.Core.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Robot.Core.FluentValidation.Validations
{
    public class MovimentarCabecaValidation : AbstractValidatorBase<MovimentarCabecaServiceRequest>
    {
        public override Task<ValidationResult> ValidateAsync(ValidationContext<MovimentarCabecaServiceRequest> context, CancellationToken cancellation = default)
        {
            When(request => request.Direcao == DirecaoCabeca.Horizontal, () => RuleFor(request => request)
                .Must(request => Validacoes.ProximoEstadoValido(request.Cabeca.EixoHorizontal, request.ProximoEstado))
                    .WithMessage("O próximo estado deve ser subsequente ao estado atual.")
                .Must(request => LimiteHorizontalValido(request.ProximoEstado))
                    .WithMessage("O limite de movimentação desta direção já foi atingido.")
                .Must(request => request.Cabeca.EixoVertical != EstadoCabecaVertical.Baixo)
                    .WithMessage("O estado da cabeça não permite movimentação horizontal."));

            When(request => request.Direcao == DirecaoCabeca.Vertical, () => RuleFor(request => request)
                .Must(request => Validacoes.ProximoEstadoValido((int)request.Cabeca.EixoVertical, request.ProximoEstado))
                    .WithMessage("O próximo estado deve ser subsequente ao estado atual.")
                .Must(request => LimiteVerticalValido(request.ProximoEstado))
                    .WithMessage("O limite de movimentação desta direção já foi atingido."));

            return Validator(context, cancellation);
        }

        public bool LimiteVerticalValido(int proximoEstado) => proximoEstado >= 1 && proximoEstado <= 3;

        public bool LimiteHorizontalValido(int proximoEstado) => proximoEstado >= 1 && proximoEstado <= 5;
    }
}
