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
            var msgError = "A oferta de viagem n�o possui rota ou per�odo v�lidos.";

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains(msgError, oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void DataInicialMaiorQueVoltaTeste()
        {
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 3, 15), new DateTime(2024, 2, 28));
            double preco = 100.0;
            var msgError = "Erro: Data de ida n�o pode ser maior que a data de volta.";

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.False(oferta.EhValido);
            Assert.Contains(msgError, oferta.Erros.Sumario);
        }
    }
}