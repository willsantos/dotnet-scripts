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
}