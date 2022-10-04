using Estacionamento.Models;

namespace Estacionamento.Tests
{
    public class VeiculoTests
    {
        [Fact()]
        [Trait("Funcionalidade", "Acelerar")]
        public void Veiculo_Acelerar_AumentaVelocidade()
        {
            var veiculo = new Veiculo();

            veiculo.Acelerar(10);

            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact()]
        [Trait("Funcionalidade", "Frear")]

        public void Veiculo_Frear_DiminuirVelocidade()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void Veiculo_TipoVeiculo_DeveSerAutomovel()
        {
            var veiculo = new Veiculo();

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
            var veiculo = new Veiculo();

            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void Veiculo_MostrarDados_DeveMostrar()
        {
            var carro = new Veiculo();
            carro.Proprietario = "Nathan";
            carro.Tipo = TipoVeiculo.Automovel;
            carro.Placa = "ASD-9999";
            carro.Cor = "azul";
            carro.Modelo = "Gol";

            string dados = carro.ToString();

            Assert.Contains("Ficha do Veiculo:", dados);

        }

    }
}