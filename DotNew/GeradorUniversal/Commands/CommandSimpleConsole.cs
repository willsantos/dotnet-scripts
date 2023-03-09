namespace GeradorUniversal.Commands;

static class CommandSimpleConsole
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
        }
        else
        {
            Console.WriteLine("O diretório já existe!");
        }
    }
}