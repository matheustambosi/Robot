using Robot.Core.Shared;
using System.ComponentModel;
using Xunit;

namespace Robot.Tests.FuncionalityTests
{
    public class SharedTest
    {
        [Theory]
        [Trait("Shared", "ProximoEstado Valido")]
        [InlineData(-1, 2)]
        [Description("Retorna false caso o proximoEstado não seja subsequente ao estadoAtual.")]
        public void Test(int estadoAtual, int proximoEstado)
        {
            // Act
            var result = Validacoes.ProximoEstadoValido(estadoAtual, proximoEstado);

            // Assert
            Assert.False(result);
        }
    }
}
