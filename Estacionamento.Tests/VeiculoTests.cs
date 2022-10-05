using Estacionamento.Models;
using Xunit.Abstractions;

namespace Estacionamento.Tests
{
    public class VeiculoTests : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTests(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("execucao do construtor invocado");
            veiculo = new Veiculo();
        }
        
        [Fact()]
        [Trait("Funcionalidade", "Acelerar")]
        public void Veiculo_Acelerar_AumentaVelocidade()
        {

            veiculo.Acelerar(10);

            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact()]
        [Trait("Funcionalidade", "Frear")]

        public void Veiculo_Frear_DiminuirVelocidade()
        {
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void Veiculo_TipoVeiculo_DeveSerAutomovel()
        {
            veiculo.Tipo = TipoVeiculo.Automovel;
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void Veiculo_DadoNomeDoProprietario_EValido()
        {
        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void VeiculoPassadoPorParametro_Acelerar_AumentaVelocidade(Veiculo modelo)
        {
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void Veiculo_MostrarDados_DeveMostrar()
        {
            Veiculo carro = new Veiculo();
            veiculo.Proprietario = "Nathan";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ASD-9999";
            veiculo.Cor = "azul";
            veiculo.Modelo = "Gol";

            string dados = veiculo.ToString();

            Assert.Contains("Ficha do Veiculo:", dados);

        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado");

        }
    }
}