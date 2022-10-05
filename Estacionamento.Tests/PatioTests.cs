using Estacionamento.Models;
using Xunit.Abstractions;

namespace Estacionamento.Tests
{
    public class PatioTests : IDisposable
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTests(ITestOutputHelper saidaConsoleTeste)
        {
            SaidaConsoleTeste = saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("execucao do construtor invocado");
            veiculo = new Veiculo();
            estacionamento = new Patio();
        }

        [Fact]
        public void Patio_Faturamento_EValido()
        {
            veiculo.Proprietario = "Nathan";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Jeep";
            veiculo.Placa = "ASD-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            double faturamento = estacionamento.TotalFaturado();
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Pessoa 1", "ASD-9999", "Preto", "Gol")]
        [InlineData("Pessoa 2", "ZXC-1111", "Preto", "Opala")]
        [InlineData("Pessoa 3", "QWE-9191", "Preto", "Fusca")]

        public void Patio_Faturamento_DeveSerValido(string proprietario, string placa,
                                                       string cor, string modelo)
        {
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Pessoa 1", "ASD-9999", "Preto", "Gol")]
        public void Patio_LocalizaVeiculo_DeveEncontrar(string proprietario, string placa,
                                                       string cor, string modelo)
        {
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var consultado = estacionamento.PesquisaVeiculo(placa);

            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void Patio_AlterarDadosVeiculoCadastrado_DeveAlterar()
        {
            veiculo.Proprietario = "Nathan";
            veiculo.Cor = "amarelo";
            veiculo.Modelo = "fusca";
            veiculo.Placa = "AAA-9999";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Nathan";
            veiculoAlterado.Cor = "preto"; //alterado
            veiculoAlterado.Modelo = "fusca";
            veiculoAlterado.Placa = "AAA-9999";

            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado");
        }
    }
}
