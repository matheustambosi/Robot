using Robot.Core.Enums;
using Robot.Core.Enums.Estados;
using Robot.Core.Exceptions;
using Robot.Core.FluentValidation.Validations;
using Robot.Core.Messaging.Controllers.Request;
using Robot.Core.Messaging.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robot.Tests.ValidationTests
{
    public class MovimentarBracoTest
    {
        private Core.Entities.Robot _robot;
        private readonly MovimentarBracoValidation _movimentarBracoValidation;

        public MovimentarBracoTest()
        {
            _robot = new Core.Entities.Robot();
            _movimentarBracoValidation = new MovimentarBracoValidation();
        }

        [Fact]
        [Trait("Braco", "Movimentar")]
        [Description("Retorna uma exception caso a direção informada não seja válida.")]
        public void MovimentarBraco_DeveriaEstourarException_SeDirecaoForInvalida()
        {
            // Arrange
            var controllerRequest = new MovimentarBracoRequest
            {
                ProximoEstado = 1,
                DirecaoBraco = (DirecaoBraco)50,
                MembroBraco = MembroBraco.Cotovelo
            };
            var request = new MovimentarBracoServiceRequest(controllerRequest, _robot.GetBraco(controllerRequest.DirecaoBraco));

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarBracoValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("Direção inválida.", ex.Message);
        }

        [Fact]
        [Trait("Braco", "Movimentar")]
        [Description("Retorna uma exception caso o membro informado não seja válido.")]
        public void MovimentarBraco_DeveriaEstourarException_SeMembroForInvalido()
        {
            // Arrange
            var controllerRequest = new MovimentarBracoRequest
            {
                ProximoEstado = 1,
                DirecaoBraco = DirecaoBraco.Direita,
                MembroBraco = (MembroBraco)50
            };
            var request = new MovimentarBracoServiceRequest(controllerRequest, _robot.GetBraco(controllerRequest.DirecaoBraco));

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarBracoValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("Membro inválido.", ex.Message);
        }

        #region Cotovelo

        [Fact]
        [Trait("Braco", "Movimentar Cotovelo")]
        [Description("Retorna uma exception caso o próximo estado não for subsequente ao estado atual (Cotovelo).")]
        public void MovimentarCotovelo_DeveriaEstourarException_SeProximoMovimentoNaoForSubsequente()
        {
            // Arrange
            var controllerRequest = new MovimentarBracoRequest
            {
                DirecaoBraco = DirecaoBraco.Direita,
                ProximoEstado = (int)EstadoCotovelo.FortementeContraido,
                MembroBraco = MembroBraco.Cotovelo
            };
            var request = new MovimentarBracoServiceRequest(controllerRequest, _robot.GetBraco(controllerRequest.DirecaoBraco));

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarBracoValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("O próximo estado deve ser subsequente ao estado atual.", ex.Message);
        }

        [Fact]
        [Trait("Braco", "Movimentar Cotovelo")]
        [Description("Retorna uma exception caso o próximo estado ultrapassar o limite do cotovelo.")]
        public void MovimentarCotovelo_DeveriaEstourarException_SeProximoMovimentoUltrapassarOLimite()
        {
            // Arrange
            var controllerRequest = new MovimentarBracoRequest
            {
                DirecaoBraco = DirecaoBraco.Direita,
                MembroBraco = MembroBraco.Cotovelo,
                ProximoEstado = 4
            };
            var request = new MovimentarBracoServiceRequest(controllerRequest, _robot.GetBraco(controllerRequest.DirecaoBraco));

            request.Braco.Cotovelo.SetEstadoCotovelo((int)EstadoCotovelo.FortementeContraido);

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarBracoValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("O limite de movimentação do cotovelo já foi atingido.", ex.Message);
        }

        #endregion

        #region Pulso

        [Fact]
        [Trait("Braco", "Movimentar Pulso")]
        [Description("Retorna uma exception caso o próximo estado não for subsequente ao estado atual (Pulso).")]
        public void MovimentarPulso_DeveriaEstourarException_SeProximoMovimentoNaoForSubsequente()
        {
            // Arrange
            var controllerRequest = new MovimentarBracoRequest
            {
                DirecaoBraco = DirecaoBraco.Direita,
                MembroBraco = MembroBraco.Pulso,
                ProximoEstado = (int)EstadoPulso.Rotacao180Positivo
            };
            var request = new MovimentarBracoServiceRequest(controllerRequest, _robot.GetBraco(controllerRequest.DirecaoBraco));

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarBracoValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("O próximo estado deve ser subsequente ao estado atual.", ex.Message);
        }

        [Fact]
        [Trait("Braco", "Movimentar Pulso")]
        [Description("Retorna uma exception caso o próximo estado ultrapassar o limite da direção Pulso.")]
        public void MovimentarPulso_DeveriaEstourarException_SeProximoMovimentoUltrapassarOLimitePulso()
        {
            // Arrange
            var controllerRequest = new MovimentarBracoRequest
            {
                DirecaoBraco = DirecaoBraco.Direita,
                MembroBraco = MembroBraco.Pulso,
                ProximoEstado = 5
            };
            var request = new MovimentarBracoServiceRequest(controllerRequest, _robot.GetBraco(controllerRequest.DirecaoBraco));

            request.Braco.Pulso.SetEstadoPulso((int)EstadoPulso.Rotacao180Positivo);

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarBracoValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("O limite de movimentação do pulso já foi atingido.", ex.Message);
        }

        [Fact]
        [Trait("Braco", "Movimentar Pulso")]
        [Description("Retorna uma exception caso tentarmos rodar o pulso com o braço em um estado diferente de Fortemente Contraido.")]
        public void MovimentarPulso_DeveriaEstourarException_SeCotoveloEstiverDiferenteDeFortementeContraidoETentarMovimentarPulso()
        {
            // Arrange
            var controllerRequest = new MovimentarBracoRequest
            {
                DirecaoBraco = DirecaoBraco.Direita,
                MembroBraco = MembroBraco.Pulso,
                ProximoEstado = 1
            };
            var request = new MovimentarBracoServiceRequest(controllerRequest, _robot.GetBraco(controllerRequest.DirecaoBraco));

            request.Braco.Pulso.SetEstadoPulso((int)EstadoPulso.EmRepouso);
            request.Braco.Cotovelo.SetEstadoCotovelo((int)EstadoCotovelo.EmRepouso);

            // Act
            var ex = Assert.ThrowsAsync<RobotException>(() => _movimentarBracoValidation.ValidateAsync(request)).Result;

            // Assert
            Assert.Equal("O estado do cotovelo não permite que o pulso seja movimentado.", ex.Message);
        }

        #endregion
    }
}
