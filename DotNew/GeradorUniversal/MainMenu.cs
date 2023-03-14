using GeradorUniversal.Commands;

namespace GeradorUniversal;

public class MainMenu
{
    public static void ExecMainMenu()
    {
        string opcao = string.Empty;
        ShowBemVindo();
        do
        {
            
            ShowMenu();
            opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    ServiceSimpleConsole.CriaConsoleApp();
                    break;
                case "2":
                    ServiceDddStella.CriaProjetoDddStella();
                    break;
                case "3":
                    Console.WriteLine("Em breve");
                    break;
                case "4":
                    Console.WriteLine("Em breve");
                    break;
                case "5":
                    Console.WriteLine("Em breve");
                    break;
                case "x":
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        } while (opcao.ToUpper() != "X");
    }

    private static void ShowBemVindo()
    {
        Console.WriteLine("Bem vindo ao Gerador de Projetos .Net");
        Console.WriteLine("Os projetos serão gerados na pasta atual");
    }

    private static void ShowMenu()
    {
        
        Console.WriteLine("Digite a opção desejada:");
        Console.WriteLine("1 - Gerar Projeto Console");
        Console.WriteLine("2 - Gerar Projeto WebApi DDD (codinome: Stella)");
        Console.WriteLine(
            "3 - Gerar Projeto WebApi DDD (codinome: Pedro) [em breve]");
        Console.WriteLine("4 - Ferramentas [em breve]");
        Console.WriteLine("5- Ajuda [em breve]");
        Console.WriteLine("x - Sair");
    }
}