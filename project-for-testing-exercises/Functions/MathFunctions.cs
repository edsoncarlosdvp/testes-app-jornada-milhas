namespace project_for_testing_exercises
{
    public class MathFunctions
    {
        public int value1 { get; set; }
        public int value2 { get; set; }
        
        public MathFunctions()
        {
        }

        public MathFunctions(int value1, int value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }


        public int Sum(int value1, int value2)
        {
            var result = value1 + value2;
            Console.WriteLine($"O resultado da soma de {value1} + {value2} é {result}");
            return result;
        }

        public int Multiply(int value1, int value2)
        {
            var result = value1 * value2;
            Console.WriteLine($"O resultado da multiplicação de {value1} + {value2} é {result}");
            return result;
        }
    }
}
