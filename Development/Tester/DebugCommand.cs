namespace JudePatch.Development.Tester;

public class DebugCommand
{
    public string Name;
    public string Description;
    public string[] Args;
    
    public DebugCommand(string? name, string? description = null,  string[] args = null)
    {
        Name = name ?? "";
        Description = description;
        Args = args ?? Array.Empty<string>();
    }

}
