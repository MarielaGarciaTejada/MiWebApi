namespace MiWebApi.Services
{
    public class MathService
    {
        // Metodo que calcula el Maximo como un divisor con el algoritmo de euclides
        public int CalcularMcd(int dividendo, int divisor)
        {
            int a = Math.Abs(dividendo);
            int b = Math.Abs(divisor);

         
            while (b != 0)
            {
                int residuo = a % b;
                a = b;
                b = residuo;
            }

            return a;
        }
    }
}