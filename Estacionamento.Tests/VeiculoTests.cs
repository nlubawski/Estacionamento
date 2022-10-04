using Estacionamento.Models;

namespace Estacionamento.Tests
{
    public class VeiculoTests
    {
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Tipo = TipoVeiculo.Automovel;

            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    

        }
    }
}