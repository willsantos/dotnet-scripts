using GeradorUniversal.Extensions;

namespace GeradorUniversal.Commands;

static class CommandDotNet
{
    public static void CriaSolution(string nomeProjeto)
    {
        var args = $"new sln -n {nomeProjeto.ToPascalCase()}";

        ExecutaComando.CallProcess(args);

    }

    public static void CriaConsole(string nomeProjeto)
    {
        var args = $"new console -n {nomeProjeto.ToPascalCase()}";

        ExecutaComando.CallProcess(args);
    }

    public static void CriaMsTest(string nomeProjeto)
    {
        var args = $"new mstest -n Testes{nomeProjeto.ToPascalCase()}";

        ExecutaComando.CallProcess(args);
    }
    
    public static void AddNaSolution(string nomeProjeto)
    {
        var args = $"sln add {nomeProjeto.ToPascalCase()}/{nomeProjeto.ToPascalCase()}.csproj";

        ExecutaComando.CallProcess(args);
    }
    
    public static void AddNaSolutionTestes(string nomeProjeto)
    {
        var args = $"sln add Testes{nomeProjeto.ToPascalCase()}/Testes{nomeProjeto.ToPascalCase()}.csproj";

        ExecutaComando.CallProcess(args);
    }
    
    public static void AddReferenciaProjetoTeste(string nomeProjeto)
    {
        var args = $"add Testes{nomeProjeto.ToPascalCase()}/Testes{nomeProjeto.ToPascalCase()}.csproj reference {nomeProjeto.ToPascalCase()}/{nomeProjeto.ToPascalCase()}.csproj";
        ExecutaComando.CallProcess(args);
    }
    
    public static void Build(string nomeProjeto)
    {
        var args = "build";
        ExecutaComando.CallProcess(args);
    }
    
    public static void Test(string nomeProjeto)
    {
        var args = $"test";
        ExecutaComando.CallProcess(args);
    }
}