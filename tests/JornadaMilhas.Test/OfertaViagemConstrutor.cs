using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("", null, "2024-02-01", "2024-02-05", 0, false)]
        [InlineData(null, "DestinoTeste", "2024-02-01", "2024-02-05", -1, false)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, true)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", -1, false)]

        public void RetornaEhValidoDeAcordoComEntrada(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
        {
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Equal(validacao, oferta.EhValido);
        }

        [Theory]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 0, "O preço da oferta de viagem deve ser maior que zero.", false)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", -1, "O preço da oferta de viagem deve ser maior que zero.", false)]
        public void RetornaUmaMensagemDeErroQuandoPrecoEhInvalido(string origem, string destino, string dataIda, string dataVolta, double preco, string msgError, bool validacao)
        {
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.False(validacao);
            Assert.Contains(msgError, oferta.Erros.Sumario);
        }

        [Fact]
        public void RetornaMensagemDeErroQuandoRotaForNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;
            var msgError = "A oferta de viagem não possui rota ou período válidos.";

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains(msgError, oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void RetornaUmaMensagemDeErroQuandoDataInicialForMaiorQueVolta()
        {
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 3, 15), new DateTime(2024, 2, 28));
            double preco = 100.0;
            var msgError = "Erro: Data de ida não pode ser maior que a data de volta.";

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.False(oferta.EhValido);
            Assert.Contains(msgError, oferta.Erros.Sumario);
        }
    }
}