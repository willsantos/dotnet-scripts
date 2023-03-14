namespace GeradorUniversal.Commands;

static class ServiceSimpleConsole
{
    internal static void CriaConsoleApp()
    {
        
        string nomeProjeto = null;
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
            CommandDotNet.CriaSolution(nomeProjeto);
            CommandDotNet.CriaConsole(nomeProjeto);
            CommandDotNet.CriaMsTest(nomeProjeto);
            CommandDotNet.AddNaSolution(nomeProjeto);
            CommandDotNet.AddNaSolutionTestes(nomeProjeto);
            CommandDotNet.AddReferenciaProjetoTeste(nomeProjeto);
            CommandDotNet.Build(nomeProjeto);
            CommandDotNet.Test(nomeProjeto);
            CommandDotNet.AddGitIgnore();
            CommandGit.Base();
        }
        else
        {
            Console.WriteLine("O diretório já existe!");
        }
    }
}