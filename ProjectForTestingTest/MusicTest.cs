using project_for_testing_exercises.Music;

namespace ProjectForTestingTest
{
    public class MusicTest
    {
        [Fact]
        public void VerificaSeNomeDaMusicaEst·Preenchido()
        {
            var musicName = "Titulo musica";
            var music = new Music(musicName);

            Assert.Equal(musicName, music.Nome);
        }

        [Fact]
        public void VerificaSeIdDaMusicaEst·Preenchido()
        {
            var musicName = "Titulo musica";
            var musicId = 08;
            var music = new Music(musicName) { Id = musicId };

            Assert.Equal(musicId, music.Id);
        }

        [Fact]
        public void VerificaMetodoToString()
        {
            var musicName = "Titulo musica";
            var musicId = 08;
            var music = new Music(musicName) { Id = musicId };
            music.Id = musicId;
            var expectedToString = $"Id: {musicId} Nome: {musicName}";

            Assert.Equal(expectedToString, music.ToString());
        }
    }
}