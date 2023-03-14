using GeradorUniversal.Extensions;

namespace GeradorUniversal.Commands;

static class CommandDotNet
{
    private static string _command = "dotnet ";
    public static void CriaSolution(string nomeProjeto)
    {
        var args = $"new sln -n {nomeProjeto.ToPascalCase()}";

        ExecutaComando.CallProcess(_command,args);

    }

    public static void CriaConsole(string nomeProjeto)
    {
        var args = $"new console -n {nomeProjeto.ToPascalCase()}";

        ExecutaComando.CallProcess(_command,args);
    }

    public static void CriaClassLibrary(string nome,string nomeProjeto)
    {
        var args = $"new classlib -n {nomeProjeto.ToPascalCase()}.{nome.ToPascalCase()}";

        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void CriaWebApi(string nomeProjeto)
    {
        var args = $"new webapi -n {nomeProjeto.ToPascalCase()}.Api";

        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void AddGitIgnore()
    {
        var args = $"new gitignore";

        ExecutaComando.CallProcess(_command,args);
    }
    public static void CriaMsTest(string nomeProjeto)
    {
        var args = $"new mstest -n {nomeProjeto.ToPascalCase()}.Testes";

        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void CriaXUnit(string nomeProjeto)
    {
        var args = $"new xunit -n {nomeProjeto.ToPascalCase()}.Testes";

        ExecutaComando.CallProcess(_command,args);
    }
    public static void AddNaSolution(string nomeProjeto)
    {
        var args = $"sln add {nomeProjeto.ToPascalCase()}/{nomeProjeto.ToPascalCase()}.csproj";

        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void AddNaSolutionTestes(string nomeProjeto)
    {
        var args = $"sln add {nomeProjeto.ToPascalCase()}.Testes/{nomeProjeto.ToPascalCase()}.Testes.csproj";

        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void AddNaSolutionCrossCutting(string nomeProjeto)
    {
        var args = $"sln add {nomeProjeto.ToPascalCase()}.CrossCutting/{nomeProjeto.ToPascalCase()}.CrossCutting.csproj";

        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void AddNaSolutionDomain(string nomeProjeto)
    {
        var args = $"sln add {nomeProjeto.ToPascalCase()}.Domain/{nomeProjeto.ToPascalCase()}.Domain.csproj";

        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void AddNaSolutionIoC(string nomeProjeto)
    {
        var args = $"sln add {nomeProjeto.ToPascalCase()}.IoC/{nomeProjeto.ToPascalCase()}.IoC.csproj";

        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void AddNaSolutionRepository(string nomeProjeto)
    {
        var args = $"sln add {nomeProjeto.ToPascalCase()}.Repository/{nomeProjeto.ToPascalCase()}.Repository.csproj";

        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void AddNaSolutionService(string nomeProjeto)
    {
        var args = $"sln add {nomeProjeto.ToPascalCase()}.Service/{nomeProjeto.ToPascalCase()}.Service.csproj";

        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void AddNaSolutionApi(string nomeProjeto)
    {
        var args = $"sln add {nomeProjeto.ToPascalCase()}.Api/{nomeProjeto.ToPascalCase()}.Api.csproj";

        ExecutaComando.CallProcess(_command,args);
    }
    public static void AddReferencia(string nomeProjeto,string pastaA, string pastaB)
    {
        var args = $"add {nomeProjeto.ToPascalCase()}.{pastaA.ToPascalCase()}/{nomeProjeto.ToPascalCase()}.{pastaA.ToPascalCase()}.csproj reference {nomeProjeto.ToPascalCase()}.{pastaB.ToPascalCase()}/{nomeProjeto.ToPascalCase()}.{pastaB.ToPascalCase()}.csproj";
        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void AddReferenciaProjetoTeste(string nomeProjeto)
    {
        var args = $"add {nomeProjeto.ToPascalCase()}.Testes/{nomeProjeto.ToPascalCase()}.Testes.csproj reference {nomeProjeto.ToPascalCase()}/{nomeProjeto.ToPascalCase()}.csproj";
        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void AddPackage(string package)
    {
        var args = $"add package {package}";
        ExecutaComando.CallProcess(_command,args);
    }
    public static void Build(string nomeProjeto)
    {
        var args = "build";
        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void Test(string nomeProjeto)
    {
        var args = $"test";
        ExecutaComando.CallProcess(_command,args);
    }
}