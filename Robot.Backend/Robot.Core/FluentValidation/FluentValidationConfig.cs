using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Robot.Core.FluentValidation.Validations;
using System.Globalization;

namespace Robot.Core.FluentValidation
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfig(this IServiceCollection services)
        {
            services.AddMvc()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<MovimentarBracoValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<MovimentarCabecaValidation>();
                    fv.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                });
        }
    }
}
