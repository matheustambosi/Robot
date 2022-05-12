using FluentValidation;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Robot.Core.FluentValidation.Base
{
    public interface IAbstractValidator<T>
    {
        public Task<ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellation = default);
        public Task<ValidationResult> Validator(ValidationContext<T> context, CancellationToken cancellation = default);
    }
}
