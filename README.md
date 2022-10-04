# Estacionamento

Neste projeto é usado o padrão de escrita AAA (Arrange, Act, Assert) para permitir que a escrita do código de teste siga uma sequência lógica,
que será útil para o entendimento e futuras manutenções.
Os códigos de testes são escritos com o frameworks de testes xUnit.

Utilizada a anotação [Fact] para testar “fatos” únicos, ou seja, um único método e quando não temos a necessidade de parâmetros.
Utilizada a anotação [Theory] para passar um conjunto de valores para um método de teste que serão entendidos como uma novo teste.

