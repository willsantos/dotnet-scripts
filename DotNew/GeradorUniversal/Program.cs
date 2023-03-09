using System.Diagnostics;
using GeradorUniversal.Extensions;

namespace GeradorUniversal;

static class Program
{
    static void Main(string[] args)
    {

        string nomeProjeto;

        do
        {
            Console.WriteLine("Digite o nome do projeto: ");
            nomeProjeto = Console.ReadLine();
        } while (nomeProjeto == null);
        
        if (!Directory.Exists(nomeProjeto))
        {
            Directory.CreateDirectory(nomeProjeto);
            Console.WriteLine($"Diretório {nomeProjeto} criado com sucesso!");
            Directory.SetCurrentDirectory(nomeProjeto);
            CriaSolution(nomeProjeto);
            CriaConsole(nomeProjeto);
            CriaMsTest(nomeProjeto);
        }
        else
        {
            Console.WriteLine("O diretório já existe!");
        }
        
        
        
        
    }

    private static void CallProcess( string args)
    {
        Process process = new Process();

        // Configura o nome do programa a ser executado
        process.StartInfo.FileName = "dotnet";

        process.StartInfo.Arguments = args;

        // Configura para que a saída do processo seja redirecionada para o console
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;

        // Inicia o processo
        process.Start();

        // Lê a saída do processo e escreve na tela
        string output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);

        // Aguarda o término do processo
        process.WaitForExit();
    }

    private static void CriaSolution(string nomeProjeto)
    {
        var args = $"new sln -n {nomeProjeto.ToPascalCase()}";
        
        CallProcess(args);

    }

    private static void CriaConsole(string nomeProjeto)
    {
        var args = $"new console -n {nomeProjeto.ToPascalCase()}";
        
        CallProcess(args);
    }

    private static void CriaMsTest(string nomeProjeto)
    {
        var args = $"new mstest -n Testes{nomeProjeto.ToPascalCase()}";
        
        CallProcess(args);
    }
    
    
}