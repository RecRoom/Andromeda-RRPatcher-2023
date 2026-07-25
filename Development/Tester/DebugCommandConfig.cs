using System.Diagnostics;

namespace JudePatch.Development.Tester;

public class DebugCommandConfig
{
    
    public Dictionary<DebugCommand, Action> commands;
    
    public void Register(DebugCommand command, Action action) => 
        commands.Add(command, action);

    /*public static void Unregister(DebugCommand command) =>  
        commands.Remove(command);*/

}