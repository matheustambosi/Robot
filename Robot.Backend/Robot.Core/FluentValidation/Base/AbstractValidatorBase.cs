using FluentValidation;
using FluentValidation.Results;
using Robot.Core.Exceptions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Robot.Core.FluentValidation.Base
{
    public class AbstractValidatorBase<T> : AbstractValidator<T>, IAbstractValidator<T>
    {
        public Task<ValidationResult> Validator(ValidationContext<T> context, CancellationToken cancellation)
        {
            var validate = base.ValidateAsync(context, cancellation);
            if (validate.Result.IsValid)
                return validate;
            else
            {
                var error = validate.Result.Errors.First();
                throw new RobotException(error.ToString());
            }
        }
    }
}
