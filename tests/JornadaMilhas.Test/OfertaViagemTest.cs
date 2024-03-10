using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemTest
    {
        [Fact]
        public void OfertaValidaTeste()
        {
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;
            var validacao = true;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Equal(validacao, oferta.EhValido);
        }

        [Fact]
        public void OfertaComRotaNulaTeste()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;
            var msgError = "A oferta de viagem não possui rota ou período válidos.";

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains(msgError, oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }
    }
}