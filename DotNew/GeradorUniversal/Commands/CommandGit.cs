using GeradorUniversal.Extensions;

namespace GeradorUniversal.Commands;

public class CommandGit
{
    private static string _command = "git";
    
    
    public static void Init()
    {
        var args = $"init";
        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void Add()
    {
        var args = $"add .";
        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void Commit()
    {
        var args = $"commit -m \":tada: Initial commit\"";
        ExecutaComando.CallProcess(_command,args);
    }
    
    public static void SayNoRacism()
    {
        var args = $"branch -m master main";
        ExecutaComando.CallProcess(_command,args);
    }

    public static void Base()
    {
        Init();
        Add();
        Commit();
        SayNoRacism();
    }
}