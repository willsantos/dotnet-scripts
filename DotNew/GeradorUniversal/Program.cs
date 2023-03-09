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
            CallProcess(nomeProjeto, CriaSolution());
            CallProcess(nomeProjeto, CriaConsole());
            CallProcess(nomeProjeto, CriaMsTest());
        }
        else
        {
            Console.WriteLine("O diretório já existe!");
        }
        
        
        
        
    }

    private static void CallProcess(string nomeProjeto, string args)
    {
        Process process = new Process();

        // Configura o nome do programa a ser executado
        process.StartInfo.FileName = "dotnet";

        process.StartInfo.Arguments = args + nomeProjeto.ToPascalCase();

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

    private static string CriaSolution()
    {
        
        return "new sln -n ";

    }

    private static string CriaConsole()
    {
        return "new console -n ";
    }

    private static string CriaMsTest()
    {
        return "new mstest -n Testes";
    }
    
    
}