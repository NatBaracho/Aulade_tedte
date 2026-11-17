using CalculadoraSoma = global::Calculadora.App.Calculadora;

namespace Calculadora.Tests;

public class CalculadoraTests
{
    [Fact]
    public void Somar_DoisNumerosPositivos()
    {
        var calculadora = new CalculadoraSoma();
        double numero1 = 10;
        double numero2 = 25;

        double resultado = calculadora.Somar(numero1, numero2);

        Assert.Equal(35, resultado);
    }

    [Theory]
    [InlineData(5, 3, 8)]
    [InlineData(-5, -3, -8)]
    [InlineData(-5, 10, 5)]
    [InlineData(0, 10, 10)]
    [InlineData(2.5, 3.5, 6)]
    public void Somar_DiferentesValores(
        double numero1,
        double numero2,
        double esperado)
    {
        var calculadora = new CalculadoraSoma();

        double resultado = calculadora.Somar(numero1, numero2);

        Assert.Equal(esperado, resultado);
    }
}
