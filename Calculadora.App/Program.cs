using Calculadora.App;

Calculadora.App.Calculadora calculadora = new Calculadora.App.Calculadora();

Console.WriteLine("Digite o primeiro numero: ");
double numero1 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Digite o segundo número: ");
double numero2 = Convert.ToDouble(Console.ReadLine());

double resultado = calculadora.Somar(numero1, numero2);

Console.WriteLine($"O Resultado da soma é : {resultado}");
