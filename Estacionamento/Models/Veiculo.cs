﻿namespace Estacionamento.Models
{

    public class Veiculo
    {
  
        private string _placa;
        private string _proprietario;
        private TipoVeiculo _tipo;

        public string Placa
        {
            get
            {
                return _placa;
            }
            set
            {
                if (value.Length != 8)
                {
                    throw new FormatException(" A placa deve possuir 8 caracteres");
                }
                for (int i = 0; i < 3; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        throw new FormatException("Os 3 primeiros caracteres devem ser letras!");
                    }
                }

                if (value[3] != '-')
                {
                    throw new FormatException("O 4° caractere deve ser um hífen");
                }

                for (int i = 4; i < 8; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new FormatException("Do 5º ao 8º caractere deve-se ter um número!");
                    }
                }
                _placa = value;

            }
        }
        
        public string Cor { get; set; }
        public double Largura { get; set; }
        public double VelocidadeAtual { get; set; }
        public string Modelo { get; set; }
        public string Proprietario
        {
            get; set;
        }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public TipoVeiculo Tipo
        {
            get { return _tipo; }
            set
            {
                if (value == null)
                {
                    _tipo = TipoVeiculo.Automovel;
                }
                else { _tipo = value; }
            }
        }

        //Métodos
        public void Acelerar(int tempoSeg)
        {
            this.VelocidadeAtual += (tempoSeg * 10);
        }

        public void Frear(int tempoSeg)
        {
            this.VelocidadeAtual -= (tempoSeg * 15);
        }


        public Veiculo()
        {

        }

        public Veiculo(string proprietario)
        {
            Proprietario = proprietario;
        }
    }
}
