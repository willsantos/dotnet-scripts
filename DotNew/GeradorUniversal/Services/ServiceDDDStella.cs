namespace GeradorUniversal.Commands;

public class ServiceDddStella
{
    internal static void CriaProjetoDddStella()
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
            CommandDotNet.CriaWebApi(nomeProjeto);
            CommandDotNet.CriaXUnit(nomeProjeto);
            CommandDotNet.CriaClassLibrary("CrossCutting",nomeProjeto);
            CommandDotNet.CriaClassLibrary("Domain",nomeProjeto);
            CommandDotNet.CriaClassLibrary("IoC",nomeProjeto);
            CommandDotNet.CriaClassLibrary("Repository",nomeProjeto);
            CommandDotNet.CriaClassLibrary("Service",nomeProjeto);
            CommandDotNet.AddNaSolutionApi(nomeProjeto);
            CommandDotNet.AddNaSolutionDomain(nomeProjeto);
            CommandDotNet.AddNaSolutionCrossCutting(nomeProjeto);
            CommandDotNet.AddNaSolutionIoC(nomeProjeto);
            CommandDotNet.AddNaSolutionRepository(nomeProjeto);
            CommandDotNet.AddNaSolutionService(nomeProjeto);
            CommandDotNet.AddNaSolutionTestes(nomeProjeto);
            CommandDotNet.AddReferencia(nomeProjeto,"Api","Domain");
            CommandDotNet.AddReferencia(nomeProjeto,"Api","IoC");
            CommandDotNet.AddReferencia(nomeProjeto,"CrossCutting","Domain");
            CommandDotNet.AddReferencia(nomeProjeto,"CrossCutting","Repository");
            CommandDotNet.AddReferencia(nomeProjeto,"CrossCutting","Service");
            CommandDotNet.AddReferencia(nomeProjeto,"IoC","CrossCutting");
            CommandDotNet.AddReferencia(nomeProjeto,"Repository","Domain");
            CommandDotNet.AddReferencia(nomeProjeto,"Service","Domain");
            CommandDotNet.AddReferencia(nomeProjeto,"Testes","Api");
            CommandDotNet.AddReferencia(nomeProjeto,"Testes","Domain");
            
            //Api
            Directory.SetCurrentDirectory($"{nomeProjeto}.Api");
            Directory.CreateDirectory("Controllers");
            File.Create($"Controllers/.gitkeep").Dispose();
            CommandDotNet.AddPackage("Microsoft.EntityFrameworkCore.Design");
            //CrossCutting
            Directory.SetCurrentDirectory($"../{nomeProjeto}.CrossCutting");
            Directory.CreateDirectory("DependencyInjection");
            Directory.CreateDirectory("Mappers");
            File.Create($"DependencyInjection/.gitkeep").Dispose();
            File.Create($"Mappers/.gitkeep").Dispose();
            CommandDotNet.AddPackage("AutoMapper");
            CommandDotNet.AddPackage("Microsoft.Extensions.DependencyInjection.Abstractions");
            CommandDotNet.AddPackage("Microsoft.EntityFrameworkCore");
            CommandDotNet.AddPackage("Microsoft.EntityFrameworkCore.SqlServer");
            //Domain
            Directory.SetCurrentDirectory($"../{nomeProjeto}.Domain");
            Directory.CreateDirectory("Contracts");
            Directory.CreateDirectory("Entities");
            Directory.CreateDirectory("Interfaces");
            Directory.CreateDirectory("interfaces/Repositories");
            Directory.CreateDirectory("interfaces/Services");
            File.Create($"Contracts/.gitkeep").Dispose();
            File.Create($"Entities/.gitkeep").Dispose();
            File.Create($"Interfaces/.gitkeep").Dispose();
            File.Create($"interfaces/Repositories/.gitkeep").Dispose();
            File.Create($"interfaces/Services/.gitkeep").Dispose();
            //IoC
            Directory.SetCurrentDirectory($"../{nomeProjeto}.IoC");
            CommandDotNet.AddPackage("Microsoft.Extensions.DependencyInjection.Abstractions");
            //Repository
            Directory.SetCurrentDirectory($"../{nomeProjeto}.Repository");
            CommandDotNet.AddPackage("Microsoft.EntityFrameworkCore");
            //Service
            Directory.SetCurrentDirectory($"../{nomeProjeto}.Service");
            CommandDotNet.AddPackage("AutoMapper");
            
            //Finaliza
            Directory.SetCurrentDirectory($"..");
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