using System.Diagnostics;

namespace GeradorUniversal.Extensions;
static class ExecutaComando
{
    internal static void CallProcess( string app,string args)
    {
        Process process = new Process();

        // Configura o nome do programa a ser executado
        process.StartInfo.FileName = app;

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
}