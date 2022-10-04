using Estacionamento.Models;
using System.Security.Cryptography.X509Certificates;

namespace Estacionamento.Tests
{
    public class PatioTests
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = "Nathan";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Jeep";
            veiculo.Placa = "ASD-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);


        }

        [Theory]
        [InlineData("Pessoa 1", "ASD-9999", "Preto", "Gol")]
        [InlineData("Pessoa 2", "ZXC-1111", "Preto", "Opala")]
        [InlineData("Pessoa 3", "QWE-9191", "Preto", "Fusca")]

        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa,
                                                       string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            //veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
            //Act
            double faturamento = estacionamento.TotalFaturado();
            //Assert
            Assert.Equal(2,faturamento);

        }
    }
}
