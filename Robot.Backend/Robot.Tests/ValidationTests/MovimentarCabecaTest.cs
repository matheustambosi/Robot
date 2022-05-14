using Robot.Core.Enums;
using Robot.Core.Enums.Estados;
using Robot.Core.Exceptions;
using Robot.Core.FluentValidation.Validations;
using Robot.Core.Messaging.Request;
using Robot.Core.Messaging.Services;
using System.ComponentModel;
using Xunit;

namespace Robot.Tests.ValidationTests
{
    public class MovimentarCabecaTest
    {
        private Core.Entities.Robot _robot;
        private readonly MovimentarCabecaValidation _movimentarCabecaValidation;

        public MovimentarCabecaTest()
        {
            _robot = new Core.Entities.Robot();
            _movimentarCabecaValidation = new MovimentarCabecaValidation();
        }

        [Fact]
        [Trait("Cabeca", "Movimentar")]
        [Description("Retorna uma exception caso a direção informada não seja válida.")]
        public void MovimentarCabecaVertical_DeveriaEstourarException_SeDirecaoForInvalida()
        {
            // Arrange
            var request = new MovimentarCabecaServiceRequest(new MovimentarCabecaRequest
            {
                Direcao = (DirecaoCabeca)50,
                ProximoEstado = (int)EstadoCabecaVertical.Cima,
            }, _robot.GetCabeca());

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarCabecaValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("Direção inválida.", ex.Message);
        }

        #region Vertical

        [Fact]
        [Trait("Cabeca", "Movimentar Vertical")]
        [Description("Retorna uma exception caso o próximo estado não for subsequente ao estado atual (Verticalmente).")]
        public void MovimentarCabecaVertical_DeveriaEstourarException_SeProximoMovimentoNaoForSubsequente()
        {
            // Arrange
            var request = new MovimentarCabecaServiceRequest(new MovimentarCabecaRequest
            {
                Direcao = DirecaoCabeca.Vertical,
                ProximoEstado = (int)EstadoCabecaVertical.Cima,
            }, _robot.GetCabeca());

            request.Cabeca.SetEixoVertical((int)EstadoCabecaVertical.Baixo);

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarCabecaValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("O próximo estado deve ser subsequente ao estado atual.", ex.Message);
        }

        [Fact]
        [Trait("Cabeca", "Movimentar Vertical")]
        [Description("Retorna uma exception caso o próximo estado ultrapassar o limite da direção vertical.")]
        public void MovimentarCabecaVertical_DeveriaEstourarException_SeProximoMovimentoUltrapassarOLimiteVertical()
        {
            // Arrange
            var request = new MovimentarCabecaServiceRequest(new MovimentarCabecaRequest
            {
                Direcao = DirecaoCabeca.Vertical,
                ProximoEstado = 2
            }, _robot.GetCabeca());

            request.Cabeca.SetEixoVertical((int)EstadoCabecaVertical.Cima);

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarCabecaValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("O limite de movimentação vertical já foi atingido.", ex.Message);
        }

        #endregion

        #region Horizontal

        [Fact]
        [Trait("Cabeca", "Movimentar Horizontal")]
        [Description("Retorna uma exception caso o próximo estado não for subsequente ao estado atual (Horizontalmente).")]
        public void MovimentarCabecaHorizontal_DeveriaEstourarException_SeProximoMovimentoNaoForSubsequente()
        {
            // Arrange
            var request = new MovimentarCabecaServiceRequest(new MovimentarCabecaRequest
            {
                Direcao = DirecaoCabeca.Horizontal,
                ProximoEstado = 5
            }, _robot.GetCabeca());

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarCabecaValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("O próximo estado deve ser subsequente ao estado atual.", ex.Message);
        }

        [Fact]
        [Trait("Cabeca", "Movimentar Horizontal")]
        [Description("Retorna uma exception caso o próximo estado ultrapassar o limite da direção horizontal.")]
        public void MovimentarCabecaHorizontal_DeveriaEstourarException_SeProximoMovimentoUltrapassarOLimiteHorizontal()
        {
            // Arrange
            var request = new MovimentarCabecaServiceRequest(new MovimentarCabecaRequest
            {
                Direcao = DirecaoCabeca.Horizontal,
                ProximoEstado = 6
            }, _robot.GetCabeca());

            request.Cabeca.SetEixoHorizontal(5);

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarCabecaValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("O limite de movimentação horizontal já foi atingido.", ex.Message);
        }

        [Fact]
        [Trait("Cabeca", "Movimentar Horizontal")]
        [Description("Retorna uma exception caso o eixo vertical esteja para baixo e tentarmos movimentar o eixo horizontal.")]
        public void MovimentarCabecaHorizontal_DeveriaEstourarException_SeEixoVerticalEstiverParaBaixoEMovimentarHorizontalmente()
        {
            // Arrange
            var request = new MovimentarCabecaServiceRequest(new MovimentarCabecaRequest
            {
                Direcao = DirecaoCabeca.Horizontal,
                ProximoEstado = 1
            }, _robot.GetCabeca());

            request.Cabeca.SetEixoHorizontal((int)EstadoCabecaHorizontal.EmRepouso);
            request.Cabeca.SetEixoVertical((int)EstadoCabecaVertical.Baixo);

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarCabecaValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("O estado da cabeça não permite movimentação horizontal.", ex.Message);
        }

        #endregion
    }
}
