using MiWebApi.Services;


namespace MiWebApi.Tests
{
    public class McdServiceTests
    {
        private readonly MathService _mathService;

        public McdServiceTests()
        {
            _mathService = new MathService();
        }

        //pruebas

        [Theory]
        [InlineData(48, 18, 6)]
        [InlineData(60, 48, 12)]
        [InlineData(25, 0, 25)]
        [InlineData(101, 10, 1)]
        public void CalcularMcd_RetornaResultadoCorrecto(int dividendo, int divisor, int esperado)
        {
            // Act
            int resultado = _mathService.CalcularMcd(dividendo, divisor);

            // Assert
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void CalcularMcd_ConDivisorCero_RetornaDividendo()
        {
            // Arrange
            int dividendo = 35;
            int divisor = 0;

            // Act
            int resultado = _mathService.CalcularMcd(dividendo, divisor);

            // Assert
            Assert.Equal(35, resultado);
        }
    }
}