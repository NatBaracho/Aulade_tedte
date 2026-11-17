# Ambiente C# e testes com xUnit no VS Code

Este guia mostra como preparar o VS Code pelo terminal, criar uma aplicacao C# e configurar testes automatizados com xUnit.

## 1. Verificar os pre-requisitos

Instale o [.NET SDK 9](https://dotnet.microsoft.com/download/dotnet/9.0) e o Visual Studio Code. Depois, abra o PowerShell e confirme que o SDK esta disponivel:

```powershell
dotnet --list-sdks
dotnet --version
code --version
```

O projeto deste repositorio usa `net9.0`, portanto e necessario ter um SDK compativel com .NET 9 instalado. Se `dotnet` ou `code` nao forem reconhecidos, instale o programa correspondente ou adicione-o ao `PATH` e abra um novo terminal.

## 2. Instalar as extensoes do VS Code

No PowerShell, instale as extensoes C# e C# Dev Kit:

```powershell
code --install-extension ms-dotnettools.csharp
code --install-extension ms-dotnettools.csdevkit
```

## 3. Criar uma aplicacao e um projeto de testes

Os comandos a seguir criam uma solucao nova chamada `Calculadora`. Execute-os dentro da pasta onde deseja criar essa solucao:

```powershell
dotnet new sln -n Calculadora
dotnet new console -n Calculadora.App -f net9.0
dotnet new xunit -n Calculadora.Tests -f net9.0
dotnet sln .\Calculadora.sln add .\Calculadora.App\Calculadora.App.csproj
dotnet sln .\Calculadora.sln add .\Calculadora.Tests\Calculadora.Tests.csproj
dotnet add .\Calculadora.Tests\Calculadora.Tests.csproj reference .\Calculadora.App\Calculadora.App.csproj
code .
```

O comando `dotnet new xunit` cria o projeto de testes com as dependencias necessarias. A referencia permite que os testes usem as classes da aplicacao.

## 4. Configurar os testes neste repositorio

Neste repositorio, o projeto da aplicacao e o projeto xUnit ja existem. Abra o terminal na pasta `Calculadora` e adicione o projeto de testes a solucao:

```powershell
cd "C:\caminho\para\Calculadora"
dotnet sln .\Calculadora.sln add .\Calculadora.Tests\Calculadora.Tests.csproj
dotnet test .\Calculadora.sln
```

O projeto de testes ja referencia `Calculadora.App`; nao e necessario adicionar essa referencia novamente. Se o projeto de testes ja estiver na solucao, nao repita o comando `dotnet sln add`.

## 5. Escrever e executar um teste

No arquivo `Calculadora.Tests\Calculadora.Tests.cs`, adicione um teste para a soma:

```csharp
using Calculadora.App;
using Xunit;

namespace Calculadora.Tests;

public class CalculadoraTests
{
    [Fact]
    public void Somar_SomaDoisNumeros_RetornaResultado()
    {
        var calculadora = new Calculadora();

        var resultado = calculadora.Somar(2, 3);

        Assert.Equal(5, resultado);
    }
}
```

Execute os testes a partir da pasta `Calculadora`:

```powershell
dotnet test .\Calculadora.sln
```

Para executar somente o programa, use:

```powershell
dotnet run --project .\Calculadora.App\Calculadora.App.csproj
```

`dotnet run` procura um projeto na pasta atual. Por isso, quando estiver na pasta `Calculadora`, informe o caminho do projeto com `--project` ou entre primeiro em `Calculadora.App`.
