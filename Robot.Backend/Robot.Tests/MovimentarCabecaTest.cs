using Robot.Core.Enums;
using Robot.Core.Exceptions;
using Robot.Core.FluentValidation.Validations;
using Robot.Core.Messaging.Request;
using System.ComponentModel;
using Xunit;

namespace Robot.Tests
{
    public class MovimentarCabecaTest
    {
        private readonly MovimentarCabecaValidation _movimentarCabecaValidation;

        public MovimentarCabecaTest()
        {
            _movimentarCabecaValidation = new MovimentarCabecaValidation();
        }

        [Fact]
        [Trait("Cabeca", "Movimentar")]
        [Description("Retorna uma exception caso o próximo estado não for subsequente ao estado atual.")]
        public void Usuario_ShouldThrowAnException_IfRegionIsNullWhenGetUsuarioByNick()
        {
            // Arrange
            var request = new MovimentarCabecaRequest
            {
                Direcao = Direcao.Horizontal,
                EstadoAtual = 2,
                ProximoEstado = 5
            };

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarCabecaValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("O próximo estado deve ser subsequente ao estado atual.", ex.Message);
        }
    }
}
