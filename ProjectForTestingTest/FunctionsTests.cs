using project_for_testing_exercises;

namespace ProjectForTestingTest
{
    public class Functions
    {
        [Fact]
        public void VerificandoSoma()
        {
            var value1 = 15;
            var value2 = 15;
            var mockResult = value1 + value2;
            var mathFunctions = new MathFunctions();

            var result = mathFunctions.Sum(value1, value2);

            Assert.Equal(mockResult, result);
        }

        [Fact]
        public void VerificandoMultiplicacao()
        {
            var value1 = 15;
            var value2 = 2;
            var mockResult = value1 * value2;
            var mathFunctions = new MathFunctions();

            var result = mathFunctions.Multiply(value1, value2);

            Assert.Equal(mockResult, result);
        }
    }
}