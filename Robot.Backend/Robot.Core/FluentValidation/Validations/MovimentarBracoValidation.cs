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
    public class MovimentarBracoValidation : AbstractValidatorBase<MovimentarBracoServiceRequest>
    {
        public override Task<ValidationResult> ValidateAsync(ValidationContext<MovimentarBracoServiceRequest> context, CancellationToken cancellation = default)
        {
            RuleFor(request => request.Direcao)
                .Must(direcao => Enum.IsDefined(typeof(DirecaoBraco), direcao))
                    .WithMessage("Direção inválida.");

            RuleFor(request => request.MembroBraco)
                .Must(membro => Enum.IsDefined(typeof(MembroBraco), membro))
                    .WithMessage("Membro inválido.");

            When(request => request.MembroBraco == MembroBraco.Cotovelo, () => RuleFor(request => request)
                .Must(request => Validacoes.ProximoEstadoValido((int)request.Braco.Cotovelo.Estado, request.ProximoEstado))
                    .WithMessage("O próximo estado deve ser subsequente ao estado atual.")
                .Must(request => LimiteCotoveloValido(request.ProximoEstado))
                    .WithMessage("O limite de movimentação do cotovelo já foi atingido."));

            When(request => request.MembroBraco == MembroBraco.Pulso, () => RuleFor(request => request)
                .Must(request => Validacoes.ProximoEstadoValido((int)request.Braco.Pulso.Estado, request.ProximoEstado))
                    .WithMessage("O próximo estado deve ser subsequente ao estado atual.")
                .Must(request => LimitePulsoValido(request.ProximoEstado))
                    .WithMessage("O limite de movimentação do pulso já foi atingido.")
                .Must(request => request.Braco.Cotovelo.Estado == EstadoCotovelo.FortementeContraido)
                    .WithMessage("O estado do cotovelo não permite que o pulso seja movimentado."));

            return Validator(context, cancellation);
        }

        public bool LimiteCotoveloValido(int proximoEstado) => proximoEstado >= 0 && proximoEstado <= 3;

        public bool LimitePulsoValido(int proximoEstado) => proximoEstado >= -2 && proximoEstado <= 4;
    }
}
