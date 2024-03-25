using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Fact]
        public void RetornaOfertaValidaQuandoDadosSaoValidos()
        {
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.True(oferta.EhValido);
        }

        [Fact]
        public void RetornaUmaMensagemDeErroQuandoPrecoEhZero()
        {
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 3, 15), new DateTime(2024, 3, 28));
            double preco = 0;
            var msgError = "O preço da oferta de viagem deve ser maior que zero.";

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.False(oferta.EhValido);
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