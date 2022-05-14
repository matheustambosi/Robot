using FluentValidation;
using FluentValidation.Results;
using Robot.Core.Enums;
using Robot.Core.Enums.Estados;
using Robot.Core.FluentValidation.Base;
using Robot.Core.Messaging.Services;
using Robot.Core.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Robot.Core.FluentValidation.Validations
{
    public class MovimentarCabecaValidation : AbstractValidatorBase<MovimentarCabecaServiceRequest>
    {
        public override Task<ValidationResult> ValidateAsync(ValidationContext<MovimentarCabecaServiceRequest> context, CancellationToken cancellation = default)
        {
            RuleFor(request => request.Direcao)
                .Must(direcao => Enum.IsDefined(typeof(DirecaoCabeca), direcao))
                    .WithMessage("Direção inválida.");

            When(request => request.Direcao == DirecaoCabeca.Horizontal, () => RuleFor(request => request)
                .Must(request => Validacoes.ProximoEstadoValido((int)request.Cabeca.EixoHorizontal, request.ProximoEstado))
                    .WithMessage("O próximo estado deve ser subsequente ao estado atual.")
                .Must(request => LimiteHorizontalValido(request.ProximoEstado))
                    .WithMessage("O limite de movimentação horizontal já foi atingido.")
                .Must(request => request.Cabeca.EixoVertical != EstadoCabecaVertical.Baixo)
                    .WithMessage("O estado da cabeça não permite movimentação horizontal."));

            When(request => request.Direcao == DirecaoCabeca.Vertical, () => RuleFor(request => request)
                .Must(request => Validacoes.ProximoEstadoValido((int)request.Cabeca.EixoVertical, request.ProximoEstado))
                    .WithMessage("O próximo estado deve ser subsequente ao estado atual.")
                .Must(request => LimiteVerticalValido(request.ProximoEstado))
                    .WithMessage("O limite de movimentação vertical já foi atingido."));

            return Validator(context, cancellation);
        }

        public bool LimiteVerticalValido(int proximoEstado) => proximoEstado >= -1 && proximoEstado <= 1;

        public bool LimiteHorizontalValido(int proximoEstado) => proximoEstado >= -2 && proximoEstado <= 2;
    }
}
